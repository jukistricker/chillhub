using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Hubs;
using chillhub.Models.ThirdParties;
using chillhub.Repositories.Interfaces;
using Confluent.Kafka;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Threading.Channels;

namespace chillhub.Workers;

public class VideoNotificationWorker : BackgroundService
{
    private readonly ILogger<VideoNotificationWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly ConsumerConfig _consumerConfig;
    private readonly string _topic;
    // Hàng đợi đệm để lưu tin nhắn nhận từ Kafka
    private readonly Channel<ConsumeResult<string, string>> _messageChannel;

    public VideoNotificationWorker(
        ILogger<VideoNotificationWorker> logger,
        IServiceProvider serviceProvider,
        IOptions<KafkaOptions> kafkaOptions)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        var options = kafkaOptions.Value;

        _topic = options.VideoTopic;

        // Hàng đợi giới hạn 50 tin nhắn để tránh quá tải RAM
        _messageChannel = Channel.CreateBounded<ConsumeResult<string, string>>(50);

        _consumerConfig = new ConsumerConfig
        {
            BootstrapServers = options.BootstrapServers,
            GroupId = "chillhub-notification-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false,
            // Tăng thời gian chờ xử lý để an toàn hơn
            SessionTimeoutMs = 60000,
            MaxPollIntervalMs = 300000,
        };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var consumer = new ConsumerBuilder<string, string>(_consumerConfig)
            .SetLogHandler((_, logMessage) =>
            {
                // Chuyển log từ thư viện C++ (librdkafka) vào ILogger của .NET
                _logger.LogInformation($"[Kafka-Internal] {logMessage.Level}: {logMessage.Message}");
            })
    .SetErrorHandler((_, error) =>
    {
        _logger.LogError($"[Kafka-Error] {error.Reason}");
    })
    .Build();
        consumer.Subscribe(_topic);

        // Bắt đầu luồng xử lý riêng biệt
        var processorTask = Task.Run(() => ProcessQueueAsync(consumer, stoppingToken), stoppingToken);

        _logger.LogInformation($"[Kafka Consumer] Đang chạy nền lắng nghe tại topic: {_topic}...");

        await Task.Run(async () =>
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var result = consumer.Consume(stoppingToken); // blocking nhưng trên thread pool
                    if (result != null)
                    {
                        await _messageChannel.Writer.WriteAsync(result, stoppingToken);
                    }
                }
            }
            catch (OperationCanceledException) { }
            finally
            {
                _messageChannel.Writer.Complete();
                consumer.Close();
            }
        }, stoppingToken);

        await processorTask;
    }

    private async Task ProcessQueueAsync(IConsumer<string, string> consumer, CancellationToken stoppingToken)
    {
        await foreach (var consumeResult in _messageChannel.Reader.ReadAllAsync(stoppingToken))
        {
            bool processed = false;
            while (!processed && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await ProcessMessageAsync(consumeResult, stoppingToken);

                    // Chỉ commit sau khi xử lý thành công
                    consumer.Commit(consumeResult);
                    processed = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"[Kafka Retry] Lỗi xử lý offset {consumeResult.Offset}. Thử lại sau 5s...");
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }
    }

    private async Task ProcessMessageAsync(ConsumeResult<string, string> consumeResult, CancellationToken ct)
    {
        using var scope = _serviceProvider.CreateScope();
        var subscriberRepo = scope.ServiceProvider.GetRequiredService<ISubscriberRepository>();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var signalRHub = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();

        using var document = JsonDocument.Parse(consumeResult.Message.Value);
        var root = document.RootElement;

        var authorId = Guid.Parse(consumeResult.Message.Key);
        var mediaId = root.GetProperty("MediaId").GetGuid();
        var title = root.GetProperty("Title").GetString() ?? "Video mới";
        var thumbnail = root.GetProperty("Thumbnail").GetString() ?? "";

        var subscriberIds = await subscriberRepo.GetSubscriberIdsByChannelIdAsync(authorId);

        if (subscriberIds.Any())
        {
            var notificationTitle = $"Kênh bạn đăng ký vừa đăng video mới: {title}";
            var userNotifications = subscriberIds.Select(subId => new UserNotification
            {
                Id = Guid.CreateVersion7(),
                UserId = subId,
                MediaId = mediaId,
                Title = notificationTitle,
                Thumbnail = thumbnail,
                IsRead = false,
                CreatedAt = DateTimeOffset.UtcNow
            }).ToList();

            await dbContext.BulkInsertAsync(userNotifications, cancellationToken: ct);

            var subscriberUserIdsStr = subscriberIds.Select(id => id.ToString()).ToList();
            
            int batchSize = 500; 
            for (int i = 0; i < subscriberIds.Count; i += batchSize)
            {
                var batchIds = subscriberIds.Skip(i).Take(batchSize).Select(id => id.ToString()).ToList();
                
                await signalRHub.Clients.Users(batchIds).SendAsync("ReceiveNotification", new
                {
                    mediaId,
                    message = notificationTitle,
                    thumbnail,
                    createdAt = DateTimeOffset.UtcNow
                }, cancellationToken: ct);

                // Nghỉ 10-20ms giữa các batch để Thread Pool của laptop kịp giải phóng tài nguyên
                await Task.Delay(15, ct); 
            }

            _logger.LogInformation($"[Xử lý] Đã gửi thông báo cho {subscriberIds.Count} người dùng.");
        }
    }
}