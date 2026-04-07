using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Utils;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Middlewares;

public static class GlobalApiErrorHandler
{
    public static void UseGlobalApiErrorHandling(
        this IApplicationBuilder app,
        IWebHostEnvironment env
    )
    {
        // Bắt exception (throw)
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var ex = context.Features
                    .Get<IExceptionHandlerFeature>()?.Error;
                var catalog = ResponseCatalog.Internal;
                var errorMessage = "internal_error";

                var logger = context.RequestServices.GetRequiredService<ILogger<ResponseCatalog>>();

                // xử lý lỗi db
                if (ex is DbUpdateException dbEx && dbEx.InnerException is Npgsql.PostgresException pgEx)
                {
                    // 23505: Unique Violation | 23503: Foreign Key Violation
                    if (pgEx.SqlState == "23505" || pgEx.SqlState == "23503")
                    {
                        var mappedMsg = DbErrorRegistry.GetErrorMessage(pgEx.ConstraintName);
                
                        if (mappedMsg != null)
                        {
                            catalog = ResponseCatalog.BadRequest;
                            errorMessage = mappedMsg;
                        }
                    }
                }

                // Switch case cho các loại Exception khác
                switch (ex)
                {
                    case ArgumentException or ArgumentNullException:
                        catalog = ResponseCatalog.BadRequest;
                        errorMessage = "invalid_parameters";
                        break;

                    case UnauthorizedAccessException:
                        catalog = ResponseCatalog.NotFound; // Giấu 403 thành 404
                        errorMessage = "not_found";
                        break;

                    case KeyNotFoundException:
                        catalog = ResponseCatalog.NotFound;
                        errorMessage = "resource_not_found";
                        break;

                    case InvalidOperationException:
                        catalog = ResponseCatalog.Conflict;
                        errorMessage = "invalid_operation_state";
                        break;

                    case NotImplementedException:
                        catalog = ResponseCatalog.NotImplemented;
                        errorMessage = "feature_under_development";
                        break;
                    
                    case DbUpdateConcurrencyException:
                        catalog = ResponseCatalog.NotFound; // Trả về 404 cho đúng bản chất
                        errorMessage = "resource_not_found"; 
                        break;

                }

                if (catalog.Status >= 500)
                {
                    logger.LogError(ex, "An unhandled exception occurred: {Message}", ex?.Message);
                }
                else
                {
                    logger.LogWarning("API Warning: {Message}", ex?.Message);
                }

                var data = env.IsDevelopment()
                    ? ex?.Message
                    : null;

                await ResponseDto
                    .Create(catalog, errorMessage, data)
                    .ExecuteAsync(context);
            });
        });

        // Bắt lỗi KHÔNG throw (404, 405, 415, ...)
        app.UseStatusCodePages(async context =>
        {
            var http = context.HttpContext;

            if (http.Response.HasStarted)
                return;

            var catalog = http.Response.StatusCode switch
            {
                400 => ResponseCatalog.BadRequest,
                401 => ResponseCatalog.Unauthorized,
                403 => ResponseCatalog.Forbidden, 
                404 => ResponseCatalog.NotFound,
                405 => ResponseCatalog.MethodNotAllowed,
                406 => ResponseCatalog.NotAcceptable,
                408 => ResponseCatalog.RequestTimeout,
                409 => ResponseCatalog.Conflict,
                410 => ResponseCatalog.Gone,
                413 => ResponseCatalog.PayloadTooLarge,
                415 => ResponseCatalog.UnsupportedMediaType,
                422 => ResponseCatalog.UnprocessableEntity,
                429 => ResponseCatalog.TooManyRequests,

                502 => ResponseCatalog.BadGateway,
                504 => ResponseCatalog.GatewayTimeout,
                _ => null
            };

            if (catalog == null)
                return;

            await ResponseDto
                .Create(catalog)
                .ExecuteAsync(http);
        });
    }
}
