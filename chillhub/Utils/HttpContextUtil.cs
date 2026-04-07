using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens; 

namespace chillhub.Utils;

public static class HttpContextUtil
{
    private static IHttpContextAccessor? _accessor;

    public static void Configure(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public static string? CurrentUserId
    {
        get
        {
            // Lấy từ ClaimsPrincipal đã được Middleware xác thực
            var user = _accessor?.HttpContext?.User;
            
            // Tìm claim "sub" (JwtRegisteredClaimNames.Sub)
            return user?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value 
                                 ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
        }
    }
    
    public static string GetBearerToken(this HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Authorization", out var header))
            return null;

        var value = header.ToString();
        return value.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) 
            ? value["Bearer ".Length..].Trim() 
            : null;
    }
    
    public static string? GetJti(this HttpContext context)
    {
        // Kiểm tra xem bạn đã lưu JTI vào Items chưa (như tôi đã gợi ý ở bước trước)
        if (context.Items.TryGetValue("Jti", out var jti))
        {
            return jti?.ToString();
        }

        // Nếu chưa có trong Items, ta lấy từ User Claims
        return context.User?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
    }
    
}