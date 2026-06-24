using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Hubs;
using chillhub.Middlewares;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.ThirdParties;
using chillhub.Repositories;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Auth;
using chillhub.Services.Interfaces.Auth;
using chillhub.Services.Interfaces.Medias;
using chillhub.Services.Interfaces.Rbac;
using chillhub.Services.Medias;
using chillhub.Services.Rbac;
using chillhub.Utils;
using Confluent.Kafka;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prometheus;
using StackExchange.Redis;
using System.Text;
using System.Threading.RateLimiting;

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
builder.Services.AddHangfire(config =>
{
    config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHangfireServer();

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    // Policy 1: Dành cho API thông thường - Phân tách theo từng Token
    options.AddPolicy("GeneralApiPolicy", context =>
    {
        // Lấy token từ Header làm chìa khóa định danh (nếu không có thì dùng IP)
        string partitionKey = context.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(partitionKey))
        {
            partitionKey = context.Connection.RemoteIpAddress?.ToString() ?? "anonymous";
        }

        // Trả về bộ đếm riêng cho THIẾT BỊ/TOKEN này
        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: partitionKey,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 10, // Thiết bị này được 600 requests/phút cho API thông thường
                Window = TimeSpan.FromSeconds(1)
            });
    });

    // Policy 2: Dành cho API nhạy cảm - Phân tách theo từng Token
    options.AddPolicy("StrictApiPolicy", context =>
    {
        string partitionKey = context.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(partitionKey))
        {
            partitionKey = context.Connection.RemoteIpAddress?.ToString() ?? "anonymous";
        }

        // Trả về bộ đếm riêng cho THIẾT BỊ/TOKEN này
        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: partitionKey,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5, // Thiết bị này chỉ được 5 requests/phút cho API nhạy cảm
                Window = TimeSpan.FromMinutes(1)
            });
    });
});

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

builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection(KafkaOptions.SectionName));

// 2. Đăng ký Kafka Producer sử dụng IOptions đã được bind ở trên
builder.Services.AddSingleton<IProducer<string, string>>(sp =>
{
    // Lấy object KafkaOptions ra từ DI Container
    var kafkaOptions = sp.GetRequiredService<IOptions<KafkaOptions>>().Value;

    if (string.IsNullOrEmpty(kafkaOptions.BootstrapServers))
    {
        throw new InvalidOperationException("Missing Kafka BootstrapServers in appsettings.json");
    }

    var producerConfig = new ProducerConfig
    {
        BootstrapServers = kafkaOptions.BootstrapServers
    };
    
    return new ProducerBuilder<string, string>(producerConfig).Build();
});

// Đăng ký Repository 
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IRbacRepository, RbacRepository>();
builder.Services.AddScoped<IPermissionGroupRepository, PermissionGroupRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMediaCategoryRepository, MediaCategoryRepository>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IMediaHistoryRepository, MediaHistoryRepository>();
builder.Services.AddScoped<IMediaReactionRepository, MediaReactionRepository>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();



// Đăng ký Service
builder.Services.AddScoped<IHangfireService, HangfireService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRbacService, RbacService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMediaHistoryService, MediaHistoryService>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();
builder.Services.AddScoped<INotificationService, NotificationService>();


//Đăng ký các Unstatic Util
builder.Services.AddSingleton<TokenUtil>();
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("Missing JWT Key"))
        )
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            // Bốc token từ Query String do SignalR tự động đính kèm khi kết nối WebSocket
            var accessToken = context.Request.Query["access_token"];
            var path = context.Request.Path;

            // Kiểm tra nếu request đang đi vào Endpoint của Hub thông báo
            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/notifications"))
            {
                // Gán token vào context để hệ thống Authentication của .NET nhận diện như một Header thông thường
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

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
builder.Services.AddSignalR();

var app = builder.Build();

app.UsePathBase("/api");

app.UseHttpsRedirection();

app.UseGlobalApiErrorHandling(app.Environment);

app.UseRouting();

app.UseCors("MultiPlatformPolicy");

app.Use(async (context, next) =>
{
    Console.WriteLine($"[Request] Protocol: {context.Request.Protocol} | Path: {context.Request.Path}");
    
    // Đảm bảo luôn gửi Header quảng cáo QUIC
    // ma=31536000: Bảo trình duyệt nhớ trong 1 năm
    // persist=1: Nhớ ngay cả khi máy tính khởi động lại hoặc đổi mạng wifi
    context.Response.Headers.Append("Alt-Svc", "h3=\":7226\"; ma=31536000; persist=1");
    
    // HSTS: Ép trình duyệt luôn dùng HTTPS (QUIC bắt buộc HTTPS)
    context.Response.Headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
    await next();
});

app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseMiddleware<RolePermissionMiddleware>();

var accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard();
}


app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");

app.UseHttpMetrics(); // Theo dõi các yêu cầu HTTP (tùy chọn)
app.MapMetrics();

using (var scope = app.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    // Sử dụng service-based API thay vì static RecurringJob
    recurringJobManager.AddOrUpdate<IHangfireService>(
        "dashboard-refresh",
        x => x.RefreshDashboard(),
        Cron.Daily(1, 0)
    );
}

app.Run();
