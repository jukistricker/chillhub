namespace chillhub.Models.Dtos.Responses.Search;

public class CursorResponse<T>
{
    public List<T> Items { get; set; } = new();
    public string? NextCursor { get; set; }
    public bool HasNextPage { get; set; }
}