namespace chillhub.Models.Dtos.Requests.Search;

public class CursorRequest
{
    public string? Cursor { get; set; }
    public bool IsDescending { get; set; } = true;
    public int PageSize { get; set; } = 10;
    public string? Search { get; set; }
}

