using chillhub.Models.Dtos.Requests.Search;

namespace chillhub.Models.Dtos.Requests;

public class CategorySaveRequest
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Entities.Media.Category ToEntity()
    {
        return new Entities.Media.Category
        {
            Id = Id ?? Guid.Empty,
            Name = Name
        };
    }
}

public class CategoryFilterRequest : CursorRequest
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}