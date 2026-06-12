using chillhub.Entities;
using chillhub.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Contexts.Configurations
{

    public class DashboardConfiguration : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> builder)
        {
            builder.HasKey(p => p.Id);

        }
    }
}
