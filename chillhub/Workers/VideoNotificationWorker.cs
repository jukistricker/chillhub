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

namespace chillhub.Workers;

public class VideoNotificationWorker : BackgroundService
{
    private readonly ILogger<VideoNotificationWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly ConsumerConfig _consumerConfig;
    private readonly string _topic;

    public VideoNotificationWorker(
        ILogger<VideoNotificationWorker> logger,
        IServiceProvider serviceProvider,
        IOptions<KafkaOptions> kafkaOptions) // Inject IOptions vào đây thay vì IConfiguration
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        var options = kafkaOptions.Value;

        _topic = options.VideoTopic;

        if (string.IsNullOrEmpty(options.BootstrapServers))
        {
            throw new InvalidOperationException("Missing Kafka BootstrapServers in appsettings.json");
        }

        _consumerConfig = new ConsumerConfig
        {
            BootstrapServers = options.BootstrapServers,
            GroupId = "chillhub-notification-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    using var consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build();
    consumer.Subscribe(_topic);

    _logger.LogInformation($"[Kafka Consumer] Đang chạy nền lắng nghe tại topic: {_topic}...");

    while (!stoppingToken.IsCancellationRequested)
    {
        ConsumeResult<string, string>? consumeResult = null;

        // 1. Chỉ bắt lỗi riêng cho việc đọc tin nhắn từ Kafka Broker
        try
        {
            consumeResult = consumer.Consume(stoppingToken);
            if (consumeResult == null) continue;
        }
        catch (ConsumeException ex)
        {
            _logger.LogWarning($"[Kafka Consumer] Broker chưa sẵn sàng hoặc lỗi kết nối ({ex.Error.Reason}). Thử lại sau 5 giây...");
            await Task.Delay(5000, stoppingToken);
            continue; // Quay lại đầu vòng lặp để consume lại
        }
        catch (OperationCanceledException)
        {
            break;
        }

        // 2. VÒNG LẶP RETRY: Đảm bảo xử lý THÀNH CÔNG tin nhắn hiện tại trước khi đi tiếp
        bool isProcessedSuccessfully = false;

        while (!isProcessedSuccessfully && !stoppingToken.IsCancellationRequested)
        {
            try
            {
                var authorIdStr = consumeResult.Message.Key;
                var eventDataJson = consumeResult.Message.Value;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var subscriberRepo = scope.ServiceProvider.GetRequiredService<ISubscriberRepository>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    using var document = JsonDocument.Parse(eventDataJson);
                    var root = document.RootElement;

                    var mediaId = root.GetProperty("MediaId").GetGuid();
                    var title = root.GetProperty("Title").GetString() ?? "Video mới";
                    var thumbnail = root.GetProperty("Thumbnail").GetString() ?? "";
                    var authorId = Guid.Parse(authorIdStr);

                    _logger.LogInformation($"[Kafka Xử lý] Đọc event video của Tác giả: {authorId}");

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

                        await dbContext.BulkInsertAsync(userNotifications, cancellationToken: stoppingToken);
                        _logger.LogInformation($"[Database Bulk] Đã nạp thẳng thành công {userNotifications.Count} dòng thông báo vào Postgres.");

                        var signalRHub = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();
                        var subscriberUserIdsStr = subscriberIds.Select(id => id.ToString()).ToList();

                        await signalRHub.Clients.Users(subscriberUserIdsStr).SendAsync(
                            "ReceiveNotification",
                            new
                            {
                                mediaId = mediaId,
                                message = notificationTitle,
                                thumbnail = thumbnail,
                                createdAt = DateTimeOffset.UtcNow
                            },
                            cancellationToken: stoppingToken
                        );

                        _logger.LogInformation($"[SignalR Realtime] Đã kích hoạt lệnh bắn realtime tới {subscriberUserIdsStr.Count} người nhận.");
                    }
                }

                // Xử lý hoàn tất mọi thứ tốt đẹp -> Đánh dấu hoàn thành để thoát vòng lặp Retry
                consumer.Commit(consumeResult);
                isProcessedSuccessfully = true; 
            }
            catch (Exception ex)
            {
                // Nếu sập DB hoặc lỗi logic, log lỗi và giữ nguyên con trỏ xử lý ở tin nhắn này
                _logger.LogError(ex, $"[Kafka Retry] Lỗi xử lý nội dung tin nhắn (Offset: {consumeResult.Offset}). Sẽ thử lại sau 5 giây...");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }

    consumer.Close();
}
}
