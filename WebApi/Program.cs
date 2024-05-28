using Infrastructure.Context;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using WebGrpc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using WebApi.Hubs;
using Infrastructure.Entites;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddGrpcClient<Courses.CoursesClient>(o => o.Address = new Uri("https://localhost:7030"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 5;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;


}).AddEntityFrameworkStores<DataContext>();



builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
    x.AccessDeniedPath = "/denied";
    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromDays(1);
    x.SlidingExpiration = true;
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<AddressManger>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<OrdersRepository>();
builder.Services.AddScoped<BatchRepository>();
builder.Services.AddScoped<UserCoursesRepository>();
builder.Services.AddScoped<ChattingRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<IToastNotificationRepository,ToastNotificationRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmailServices>();

builder.Services.AddScoped<AddressService>();
builder.Services.AddSingleton<JwtTokenGenerator>();

// Add SignalR services
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BackOfficeCors", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

var scoped = app.Services.CreateScope();
var services = scoped.ServiceProvider;
var dbContext = services.GetRequiredService<DataContext>();
await StoreContextSeed.SeedAsync(dbContext);

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BackOfficeCors");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Resources/images")),
    RequestPath = "/Resources/images"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Map SignalR hub
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<SignalRServiceHub>("/SignalR-hub");
});

app.Run();
