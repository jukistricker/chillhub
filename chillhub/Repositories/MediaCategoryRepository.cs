using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Repositories.Interfaces;

namespace chillhub.Repositories
{
    public class MediaCategoryRepository : Repository<MediaCategory>, IMediaCategoryRepository
    {
        public MediaCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
