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

        // 1. Kiểm tra Metadata (Anonymous/No Auth) 
        if (endpoint.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            await _next(context); return;
        }

        var requiredPermission = endpoint.Metadata.GetMetadata<RequiredPermissionAttribute>()?.Permission;
        var isAuthorizeOnly = endpoint.Metadata.GetMetadata<AuthorizeAttribute>() != null;

        if (string.IsNullOrEmpty(requiredPermission) && !isAuthorizeOnly)
        {
            await _next(context); return;
        }

        // 2. Extract Token
        if (!context.Request.Headers.TryGetValue("Authorization", out var header))
        {
            await ReturnError(context, ResponseCatalog.Unauthorized); return;
        }

        var token = header.ToString()["Bearer ".Length..].Trim();
        if (string.IsNullOrEmpty(token)) { await ReturnError(context, ResponseCatalog.Unauthorized); return; }

        // 3. CHẶN SỚM 
        
        // Bước 3.1: Read JTI (Chỉ parse chuỗi, không tính toán chữ ký)
        var jti = _tokenUtil.GetJti(token); 
        if (string.IsNullOrEmpty(jti))
        {
            await ReturnError(context, ResponseCatalog.Unauthorized); return;
        }

        // Bước 3.2: Check Redis bằng JTI 
        var redisValue = await _redis.StringGetAsync($"session:{jti}");
        if (redisValue.IsNullOrEmpty)
        {
            await ReturnError(context, ResponseCatalog.Unauthorized); return;
        }

        // Bước 3.3: Chỉ khi Redis OK, mới Validate Crypto
        // Điều này chặn các cuộc tấn công spam Token giả 
        var principal = await _tokenUtil.ValidateCryptoAsync(token);
        if (principal == null) //Lỗi ở đây
        {
            await ReturnError(context, ResponseCatalog.Unauthorized); return;
        }

        // 4. Load & Attach Session
        var session = DataUtil.RedisValueToObject<UserSession>(redisValue);
        if (session == null) { await ReturnError(context, ResponseCatalog.Unauthorized); return; }
        
        context.Items["UserSession"] = session;
        context.User = principal; // Đẩy vào context.User để dùng User.FindFirst() nếu cần

        // 5. Check Permission
        if (!string.IsNullOrEmpty(requiredPermission))
        {
            if (!session.Permissions.Contains(requiredPermission))
            {
                await ReturnError(context, ResponseCatalog.NotFound); return;
            }
        }
        context.Items["Jti"] = jti;
        Console.WriteLine("Jti: "+context.Items["Jti"]);

        await _next(context);
    }

    private static async Task ReturnError(HttpContext context, ResponseCatalog catalog)
    {
        await ResponseDto.Create(catalog).ExecuteAsync(context);
    }
}