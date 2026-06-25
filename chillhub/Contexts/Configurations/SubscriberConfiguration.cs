using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace chillhub.Contexts.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.SubscriberId, x.ChannelId })
                   .IsUnique();

            builder.HasIndex(x => x.ChannelId);
            builder.HasIndex(x => x.SubscriberId);

            // 4. INDEX ĐIỀU KIỆN (Partial Index - Độc quyền cho DB như PostgreSQL):
            // Tối ưu riêng cho tính năng gửi Notification. Khi một Kênh ra video mới, 
            // bạn chỉ cần quét những Subscriber có bật chuông thông báo (IsNotice == true).
            builder.HasIndex(x => new { x.ChannelId, x.SubscriberId })
                   .HasFilter("\"is_notice\" = true"); // Chỉ đưa các bản ghi có IsNotice = true vào Index này để giảm kích thước Index
                   

            // 5. Định dạng dữ liệu PostgreSQL
            builder.Property(x => x.IsNotice)
                   .HasDefaultValue(true)
                   .IsRequired();

            builder.HasOne(s => s.Channel)
              .WithMany() 
              .HasForeignKey(s => s.ChannelId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}