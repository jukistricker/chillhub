using chillhub.Models.Dtos.Responses;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace chillhub.Utils;

public static class HttpContextUtil
{
    public static Guid? GetUserId(ClaimsPrincipal? user)
    {
        string? userId= user?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
               ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Guid.Empty;
        }
        return Guid.Parse(userId);
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

    public static UserSession? GetUserSession(this HttpContext? context)
    {
        if (context == null) return null;

        if (context.Items.TryGetValue("UserSession", out var sessionObj) &&
            sessionObj is UserSession userSession)
        {
            return userSession;
        }

        return null;
    }
}