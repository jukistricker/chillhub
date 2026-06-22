using chillhub.Entities.Media;
using chillhub.Models.Dtos.Responses;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using StackExchange.Redis;

namespace chillhub.Services.Medias
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IDatabase _redis;
        private readonly string _subscriberKey= "channel:subs:";

        public SubscriberService(ISubscriberRepository subscriberRepository,
            IConnectionMultiplexer redis)
        {
            _subscriberRepository = subscriberRepository;
            _redis = redis.GetDatabase();
        }

        public async Task<bool> SubscribeAsync(Guid subscriberId, Guid channelId, bool isNotice = true)
        {
            var sub = await _subscriberRepository.GetAsync(subscriberId, channelId);

            // 1. Xử lý DB
            if (sub == null)
            {
                // Chưa sub -> Thêm mới
                sub = new Subscriber
                {
                    Id=Guid.CreateVersion7(),
                    SubscriberId = subscriberId,
                    ChannelId = channelId,
                    IsNotice = isNotice
                };
                await _subscriberRepository.AddAsync(sub);
            }
            else
            {
                // Đã sub -> Cập nhật lại trạng thái isNotice nếu người dùng muốn đổi
                sub.IsNotice = isNotice;
            }

            await _subscriberRepository.SaveChangesAsync();

            // 2. Cập nhật Cache bằng HASH
            // Key: channel:subs:{channelId} | Field: subscriberId | Value: isNotice
            string key = GetSubscriberKey(channelId);
            await RedisUtil.SetHashAsync(_redis, key, new[] {
                new KeyValuePair<string, object>(subscriberId.ToString(), isNotice)
            });

            return true;
        }

        public async Task<bool> UnsubscribeAsync(Guid subscriberId, Guid channelId)
        {
            var sub = await _subscriberRepository.GetAsync(subscriberId, channelId);
            if (sub == null) return true;

            // 1. Xóa DB
            _subscriberRepository.Remove(sub);
            await _subscriberRepository.SaveChangesAsync();

            // 2. Xóa khỏi Cache HASH
            string key = GetSubscriberKey(channelId);
            await RedisUtil.DeleteFieldsAsync(_redis, key, subscriberId.ToString());

            return true;
        }

        public async Task<SubscriberResponse> GetSubscriberStatusAsync(Guid subscriberId, Guid channelId)
        {
            string key = GetSubscriberKey(channelId);
            string field = subscriberId.ToString();

            // 1. Kiểm tra xem field có tồn tại trong Redis Hash không
            bool hasField = await RedisUtil.FieldExistsAsync(_redis, key, field);
            if (hasField)
            {
                // Cache Hit: Lấy giá trị isNotice trực tiếp 
                bool isNotice = await RedisUtil.GetFieldAsync<bool>(_redis, key, field);
                return new SubscriberResponse
                {
                    IsSubscribed = true,
                    IsNotice = isNotice,
                };
            }

            // 2. Cache Miss: Tìm kiếm một lần duy nhất dưới DB
            var sub = await _subscriberRepository.GetAsync(subscriberId, channelId);

            if (sub != null)
            {
                // 3. Bồi đắp lại Cache đầy đủ thông tin
                await RedisUtil.SetHashAsync(_redis, key, new[] {
                    new KeyValuePair<string, object>(field, sub.IsNotice)
                });

                return new SubscriberResponse
                {
                    IsSubscribed = true,
                    IsNotice = sub.IsNotice
                };
            }

            // 4. Hoàn toàn chưa subscribe
            return new SubscriberResponse
            {
                IsSubscribed = false,
                IsNotice = false
            };
        }
        private string GetSubscriberKey(Guid channelId) {
            return $"{_subscriberKey}{channelId}";
        }
    }
}