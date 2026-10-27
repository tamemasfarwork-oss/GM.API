using GM.API.Services;
using GM.BLL.Interfaces;
using GM.BLL.Services;
using GM.BLL.Settings;
using GM.DAL.Data;
using GM.DAL.Interfaces;
using GM.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog;
using System.Text;
using System.Threading.RateLimiting;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)  // لا تكتب ضجيج إطار العمل
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log-.txt",
        rollingInterval: RollingInterval.Day,   // ملف جديد كل يوم
        retainedFileCountLimit: 30)             // احتفظ بآخر 30 يوم بس
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "الصق التوكن فقط بدون كلمة Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// قاعدة البيانات
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
        options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
});
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

//----------------------------------------------------------------------------------------------------

builder.Services.AddRateLimiter(options =>
{
// الكود اللي بيرجع لما ينرفض الطلب: 429 = طلبات كثيرة
options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

// ① الحد العام: كل مستخدم 100 طلب بآخر دقيقة
options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(ctx =>
    RateLimitPartition.GetSlidingWindowLimiter(
        partitionKey: ctx.User.FindFirst("sub")?.Value                 // المستخدم المسجّل
                      ?? ctx.Connection.RemoteIpAddress?.ToString()     // أو الـ IP إذا مو مسجّل
                      ?? "unknown",
        factory: _ => new SlidingWindowRateLimiterOptions
        {
            PermitLimit = 100,                     // كم طلب مسموح
            Window = TimeSpan.FromMinutes(1),      // خلال كم وقت
            SegmentsPerWindow = 6,                 // الدقيقة مقسومة 6 أقسام (كل 10 ثواني)
            QueueLimit = 0                         // الزايد بينرفض فوراً، ما بيستنى بالدور
        }));


    options.AddPolicy("login", ctx =>
       RateLimitPartition.GetSlidingWindowLimiter(
           partitionKey: ctx.Connection.RemoteIpAddress?.ToString() ?? "unknown",
           factory: _ => new SlidingWindowRateLimiterOptions
           {
               PermitLimit = 5,
               Window = TimeSpan.FromMinutes(1),
               SegmentsPerWindow = 6,
               QueueLimit = 0
           }));

    // لما ينرفض طلب: سجّله باللوغ ورجّع رسالة واضحة
    options.OnRejected = async (context, ct) =>
    {
        var logger = context.HttpContext.RequestServices
            .GetRequiredService<ILoggerFactory>().CreateLogger("RateLimit");

        logger.LogWarning("تجاوز حد الطلبات {Path} من {Ip}",
            context.HttpContext.Request.Path,
            context.HttpContext.Connection.RemoteIpAddress);

        await context.HttpContext.Response.WriteAsJsonAsync(
            new { message = "طلبات كثيرة، انتظر قليلاً وحاول مرة أخرى" }, ct);
    };
});

//----------------------------------------------------------------------------------------------------
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
// الخدمات
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddScoped<ITypeSub, TypeSub>();
builder.Services.AddScoped<ITypeSubRepository, TypeSubRepository>();

builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchServies, BranchServies>();

builder.Services.AddScoped<ISubRepository, SubRepositoery>();
builder.Services.AddScoped<ISubServies, SubServies>();

builder.Services.AddScoped<ITreainersRepository, TrinersRepositoery>();
builder.Services.AddScoped<ITrinersServies, TrinersServies>();

builder.Services.AddScoped<IPrivateTrainRepository, PrivateTrainRepositry>();
builder.Services.AddScoped<IPrivateTrainServies, PrivateTrainServies>();

// تسجيل الدخول والتوكن
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IproductServies, ProductServies>();
builder.Services.AddScoped<IPrductRepo, ProductRepo>();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleServies, SaleServies>();


var jwt = builder.Configuration.GetSection("Jwt").Get<JwtSettings>()!;
if (string.IsNullOrWhiteSpace(jwt.Key) || jwt.Key.Length < 32)
    throw new InvalidOperationException("Jwt:Key is missing or shorter than 32 characters.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.MapInboundClaims = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwt.Issuer,
            ValidateAudience = true,
            ValidAudience = jwt.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("https://gm-app-test1.netlify.app", "http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});





var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseRateLimiter();
app.UseAuthorization();

app.UseMiddleware<GM.API.Middleware.ErrorLoggingMiddleware>();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();