namespace chillhub.Utils;

public static class StringUtil
{
    public static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Concat(input.Select((x, i) =>
                i > 0 && char.IsUpper(x) ? "_" + x : x.ToString()))
            .ToLower();
    }
    
    public static string ToPascalCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return string.Concat(input.Split('_')
            .Select(s => char.ToUpper(s[0]) + s.Substring(1)));
    }

    public static string? ProcessSelectFields(string? select)
    {
        if (string.IsNullOrEmpty(select)) return null;
        // Chuyển "username,created_at" -> "Username,CreatedAt"
        return string.Join(",", select.Split(',').Select(s => ToPascalCase(s.Trim())));
    }
    
    public static string GetSelectFields<T>(string? customSelect = null)
    {
        // Nếu Frontend có gửi select cụ thể, ưu tiên dùng cái đó
        if (!string.IsNullOrWhiteSpace(customSelect))
        {
            return ProcessSelectFields(customSelect)!;
        }

        // Nếu không, tự động lấy toàn bộ Public Properties của Class T
        var properties = typeof(T).GetProperties()
            .Select(p => p.Name);
            
        return string.Join(", ", properties);
    }

}