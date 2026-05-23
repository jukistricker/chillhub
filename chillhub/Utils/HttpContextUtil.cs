using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace chillhub.Utils;

public static class HttpContextUtil
{
    public static string? GetUserId(ClaimsPrincipal? user)
    {
        return user?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
               ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public static string? GetBearerToken(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Authorization", out var header))
            return null;

        var value = header.ToString();
        return value.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
            ? value["Bearer ".Length..].Trim()
            : null;
    }

    public static string? GetJti(HttpContext context)
    {
        if (context.Items.TryGetValue("Jti", out var jti))
        {
            return jti?.ToString();
        }

        return context.User?.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
    }
}