using chillhub.Models.Dtos.Responses;

namespace chillhub.Middlewares;
using Attributes;
using Models.Dtos.Responses.Shared;
using Utils;
using Microsoft.AspNetCore.Authorization;
using StackExchange.Redis;

public class RolePermissionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDatabase _redis;
    private readonly TokenUtil _tokenUtil;

    public RolePermissionMiddleware(RequestDelegate next, IConnectionMultiplexer redis, TokenUtil tokenUtil)
    {
        _next = next;
        _redis = redis.GetDatabase();
        _tokenUtil = tokenUtil;
    }

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint == null) { await _next(context); return; }

        if (endpoint.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            await _next(context); return;
        }

        var isAuthorizeOnly = endpoint.Metadata.GetMetadata<AuthorizeAttribute>() != null;
        var requiredPermission = endpoint.Metadata.GetMetadata<RequiredPermissionAttribute>()?.Permission;

        if (!isAuthorizeOnly && string.IsNullOrEmpty(requiredPermission))
        {
            await _next(context); return;
        }

        if (context.User?.Identity?.IsAuthenticated != true)
        {
            await ReturnError(context, ResponseCatalog.Unauthorized); return;
        }

        var jti = context.User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti)?.Value;

        // Check Redis
        var redisValue = await _redis.StringGetAsync($"session:{jti}");
        if (redisValue.IsNullOrEmpty)
        {
            await ReturnError(context, ResponseCatalog.Unauthorized); return;
        }

        var session = DataUtil.RedisValueToObject<UserSession>(redisValue);
        if (session == null) { await ReturnError(context, ResponseCatalog.Unauthorized); return; }

        // Check Permission
        if (!string.IsNullOrEmpty(requiredPermission) && !session.Permissions.Contains(requiredPermission))
        {
            await ReturnError(context, ResponseCatalog.NotFound); return;
        }

        context.Items["UserSession"] = session;
        context.Items["Jti"] = jti;

        await _next(context);
    }

    private static async Task ReturnError(HttpContext context, ResponseCatalog catalog)
    {
        await ResponseDto.Create(catalog).ExecuteAsync(context);
    }
}