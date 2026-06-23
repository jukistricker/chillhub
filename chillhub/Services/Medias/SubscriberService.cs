using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace chillhub.Services.Medias
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IDatabase _redis;
        private readonly string _subscriberKey= "channel:subs:";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubscriberService(ISubscriberRepository subscriberRepository,
            IConnectionMultiplexer redis,
            IHttpContextAccessor httpContextAccessor)
        {
            _subscriberRepository = subscriberRepository;
            _redis = redis.GetDatabase();
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SubscribeBatchAsync(List<SubscribeBatchRequest> requests)
        {
            if (requests == null || !requests.Any()) return true;

            // Nếu 1 user spam Subscribe liên tục, chỉ giữ lại bản ghi có CreatedAt MỚI NHẤT
            var cleanRequests = requests
                .GroupBy(r => new { r.SubscriberId, r.ChannelId })
                .Select(g => g.MaxBy(r => r.CreatedAt))
                .Where(r => r != null)
                .ToList();

            var subscriberEntities = cleanRequests.Select(req => new Subscriber
            {
                Id = Guid.CreateVersion7(),
                SubscriberId = req!.SubscriberId,
                ChannelId = req.ChannelId,
                IsNotice = req.IsNotice,
                CreatedAt = req.CreatedAt
            }).ToList();

            var bulkConfig = new BulkConfig
            {
                UpdateByProperties = new List<string> { nameof(Subscriber.SubscriberId), nameof(Subscriber.ChannelId) },
                PropertiesToExcludeOnUpdate = new List<string> { nameof(Subscriber.Id), nameof(Subscriber.CreatedAt) }
            };

            await _subscriberRepository.BulkInsertOrUpdateAsync(subscriberEntities, bulkConfig);

            // update redis cache
            var groupedByChannel = cleanRequests.GroupBy(r => r!.ChannelId);
            foreach (var channelGroup in groupedByChannel)
            {
                string redisKey = GetSubscriberKey(channelGroup.Key);
                var hashEntries = channelGroup
                    .Select(req => new HashEntry(req!.SubscriberId.ToString(), req.IsNotice.ToString().ToLower()))
                    .ToArray();

                await _redis.HashSetAsync(redisKey, hashEntries);
            }

            return true;
        }

        public async Task<bool> UnsubscribeBatchAsync(List<UnsubscribeBatchRequest> requests)
        {
            if (requests == null || !requests.Any()) return true;

            var cleanRequests = requests
                .GroupBy(r => new { r.SubscriberId, r.ChannelId })
                .Select(g => g.MaxBy(r => r.CreatedAt))
                .Where(r => r != null)
                .ToList();

            var entitiesToDelete = cleanRequests.Select(req => new Subscriber
            {
                SubscriberId = req!.SubscriberId,
                ChannelId = req.ChannelId
            }).ToList();

            var bulkDeleteConfig = new BulkConfig
            {
                // Chỉ định đối chiếu bản ghi để xóa dựa theo cặp ID này thay vì Khóa chính
                UpdateByProperties = new List<string> { nameof(Subscriber.SubscriberId), nameof(Subscriber.ChannelId) }
            };

            await _subscriberRepository.BulkDeleteAsync(entitiesToDelete, bulkDeleteConfig);

            var groupedByChannel = cleanRequests.GroupBy(r => r!.ChannelId);
            foreach (var channelGroup in groupedByChannel)
            {
                string redisKey = GetSubscriberKey(channelGroup.Key);

                // Mảng các field cần xóa khỏi Hash của Channel này
                var fieldsToDelete = channelGroup
                    .Select(req => (RedisValue)req!.SubscriberId.ToString())
                    .ToArray();

                // Lệnh HashDeleteAsync nhận mảng RedisValue để xóa hàng loạt field trong 1 Round-trip
                await _redis.HashDeleteAsync(redisKey, fieldsToDelete);
            }

            return true;
        }
        public async Task<IResult> GetSubscriberStatusAsync( Guid channelId)
        {
            Guid? subscriberId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
            string key = GetSubscriberKey(channelId);
            string field = subscriberId.ToString();
            

            // 1. Kiểm tra xem field có tồn tại trong Redis Hash không
            bool hasField = await RedisUtil.FieldExistsAsync(_redis, key, field);
            if (hasField)
            {
                // Cache Hit: Lấy giá trị isNotice trực tiếp 
                bool isNotice = await RedisUtil.GetFieldAsync<bool>(_redis, key, field);
                return ResponseDto.Create(ResponseCatalog.Success, 
                    "subscriber.status",
                    new SubscriberResponse
                    {
                        IsSubscribed = true,
                        IsNotice = isNotice,
                    });
            }

            // 2. Cache Miss: Tìm kiếm một lần duy nhất dưới DB
            var sub = await _subscriberRepository.GetAsync(subscriberId.Value, channelId);

            if (sub != null)
            {
                // 3. Bồi đắp lại Cache đầy đủ thông tin
                await RedisUtil.SetHashAsync(_redis, key, new[] {
                    new KeyValuePair<string, object>(field, sub.IsNotice)
                });
                return ResponseDto.Create(ResponseCatalog.Success,
                    "subscriber.status",
                    new SubscriberResponse
                    {
                        IsSubscribed = true,
                        IsNotice = sub.IsNotice
                    });

            }

            // 4. Hoàn toàn chưa subscribe
            return ResponseDto.Create(ResponseCatalog.Success,
                "subscriber.status",
                new SubscriberResponse
                {
                    IsSubscribed = false,
                    IsNotice = false
                });
           
        }
        private string GetSubscriberKey(Guid channelId) {
            return $"{_subscriberKey}{channelId}";
        }
    }
}