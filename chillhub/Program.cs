using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Middlewares;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Auth;
using chillhub.Services.Interfaces.Auth;
using chillhub.Services.Interfaces.Rbac;
using chillhub.Services.Rbac;
using chillhub.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    
    options.ListenAnyIP(7226, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        listenOptions.UseHttps(); 
    });
});

// PostgreSQL
builder.Services.AddDbContext<AppDbContext>(opt=>{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(sp => {
    var connStr = builder.Configuration.GetConnectionString("Redis") ?? builder.Configuration["Redis:ConnectionString"];
    var options = ConfigurationOptions.Parse(connStr);
    options.AbortOnConnectFail = false; 
    return ConnectionMultiplexer.Connect(options);
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        // Lấy lỗi đầu tiên từ ModelState
        var errorMessage = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .FirstOrDefault() ?? "invalid.request_format";

        // Trả về ResponseDto chuẩn của bạn
        return new BadRequestObjectResult(ResponseDto.Create(ResponseCatalog.BadRequest, errorMessage));
    };
});

builder.Services.Configure<PasswordHasherOptions>(opt =>
{
    // Giảm xuống mức 10,000 hoặc 5,000
    opt.IterationCount = 10000; 
    
    // Đảm bảo dùng PBKDF2 với SHA256 .CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "chillhub API", Version = "v1" });

    // 1. Định nghĩa kiểu bảo mật JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter token with format: Bearer {your_token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // 2. Áp dụng bảo mật này cho tất cả API
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();

// Đăng ký Repository 
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IRbacRepository, RbacRepository>();
builder.Services.AddScoped<IPermissionGroupRepository, PermissionGroupRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Đăng ký Service
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRbacService, RbacService>();

//Đăng ký các Unstatic Util
builder.Services.AddSingleton<TokenUtil>();
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddAuthorization();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MultiPlatformPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins ?? new[] { "http://localhost:2999" }) // Fallback nếu quên cấu hình
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Quan trọng: Cho phép gửi Cookie/Auth Header
    });
});

var app = builder.Build();

app.UseRouting();

// Phải nằm SAU UseRouting và TRƯỚC UseAuthorization
app.UseCors("MultiPlatformPolicy");

app.Use(async (context, next) =>
{
    // Log giao thức của request hiện tại ra Console
    Console.WriteLine($"[Request] Protocol: {context.Request.Protocol} | Path: {context.Request.Path}");
    
    // Đảm bảo luôn gửi Header quảng cáo QUIC
    // ma=31536000: Bảo trình duyệt nhớ trong 1 năm
    // persist=1: Nhớ ngay cả khi máy tính khởi động lại hoặc đổi mạng wifi
    context.Response.Headers.Append("Alt-Svc", "h3=\":7226\"; ma=31536000; persist=1");
    
    // HSTS: Ép trình duyệt luôn dùng HTTPS (QUIC bắt buộc HTTPS)
    context.Response.Headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
    await next();
});

var accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UsePathBase("/api");

app.UseHttpsRedirection();

app.UseGlobalApiErrorHandling(app.Environment);

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.UseMiddleware<RolePermissionMiddleware>();

app.MapControllers();

app.UseHttpMetrics(); // Theo dõi các yêu cầu HTTP (tùy chọn)
app.MapMetrics();

app.Run();
