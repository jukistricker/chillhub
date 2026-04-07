namespace chillhub.Models.Dtos.Responses.Search;

public class PagedResponse<T>
{
    public List<T> Items { get; set; } = new();
    public string? NextCursor { get; set; }
    public int Count { get; set; }

    public PagedResponse(List<T> items, string? nextCursor)
    {
        Items = items;
        NextCursor = nextCursor;
        Count = items.Count;
    }
}