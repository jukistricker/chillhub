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
            try
            {
                var consumeResult = consumer.Consume(stoppingToken);
                if (consumeResult == null) continue;

                var authorIdStr = consumeResult.Message.Key;
                var eventDataJson = consumeResult.Message.Value;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var subscriberRepo = scope.ServiceProvider.GetRequiredService<ISubscriberRepository>();

                    // Lấy trực tiếp AppDbContext ra để thực hiện Bulk hoạt động ở tầng thấp
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    // Parse JSON payload từ Kafka
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

                        // Đảy realtime qua signalR hub
                        var signalRHub = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();

                        // Chuyển mảng Guid thành mảng chuỗi string theo đúng chuẩn nhận diện của Users()
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

                // Xác nhận hoàn thành để dịch chuyển dấu Offset sang tin nhắn tiếp theo
                consumer.Commit(consumeResult);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Kafka Consumer] Lỗi xảy ra trong quá trình xử lý thông báo sự kiện.");
                await Task.Delay(5000, stoppingToken);
            }
        }

        consumer.Close();
    }
}
