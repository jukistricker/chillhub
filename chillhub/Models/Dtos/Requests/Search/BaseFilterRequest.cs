using System.ComponentModel.DataAnnotations;
using chillhub.Utils;

namespace chillhub.Models.Dtos.Requests.Search;

public class BaseFilterRequest
{
    public string? Cursor { get; set; }
    
    [Range(1, 100, ErrorMessage = "filter.limit.range_1_100")]
    public int Limit { get; set; } = 20;
    public string? Search { get; set; } 
    public string? Select { get; set; }
    public string? Sort { get; set; } = "Id";
    public bool IsDescending { get; set; } = true; // Mặc định luôn là giảm dần

    // 1. Lấy trường đầu tiên làm mỏ neo cho Cursor
    public string PrimarySortField => Sort?.Split(',').FirstOrDefault()?.Trim() ?? "Id";
    public string SortField => StringUtil.ToPascalCase(PrimarySortField);

    // 2. Tạo chuỗi FullSortParam đồng nhất một chiều
    public string FullSortParam 
    {
        get 
        {
            string direction = IsDescending ? "desc" : "asc";
            
            if (string.IsNullOrWhiteSpace(Sort)) return $"Id {direction}";

            // Chuyển mọi trường trong Sort sang PascalCase và gắn hậu tố direction
            var parts = Sort.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => $"{StringUtil.ToPascalCase(s.Trim())} {direction}")
                .ToList();

            // Luôn đảm bảo có Id ở cuối cùng chiều để Deterministic
            if (!parts.Any(p => p.StartsWith("Id", StringComparison.OrdinalIgnoreCase)))
            {
                parts.Add($"Id {direction}");
            }

            return string.Join(", ", parts);
        }
    }
    
    
}