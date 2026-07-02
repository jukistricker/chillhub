using chillhub.Entities.Auth;

namespace chillhub.Entities.Media;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<MediaCategory> MediaCategories { get; set; }
}
