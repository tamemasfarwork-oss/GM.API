using GM.BLL.Interfaces;
using GM.BLL.Services;
using GM.DAL.Data;
using GM.DAL.Interfaces;
using GM.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
//using GM.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// جلب Connection String
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
string? connectionString = configuration.GetConnectionString("DefaultConnection");

// Validate connection string.
if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Connection string not found.");
    return;
}
// تسجيل AppDbContext باستعمال SQL Server
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .Options;


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddScoped<ITypeSub,TypeSub>();
builder.Services.AddScoped<ITypeSubRepository, TypeSubRepository>();

builder .Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchServies,BranchServies>();

builder.Services.AddScoped<ISubRepository, SubRepositoery>();
builder.Services.AddScoped<ISubServies, SubServies>();

// في Program.cs
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
