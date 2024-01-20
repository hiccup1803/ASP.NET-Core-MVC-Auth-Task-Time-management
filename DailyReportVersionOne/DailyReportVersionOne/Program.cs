using DailyReportVersionOne.Models;
using DailyReportVersionOne.WebSockets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSocketManager;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
//Configure Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("SQLServerIdentityConnection") ?? throw new InvalidOperationException("Connection string 'SQLServerIdentityConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//Configuration Identity Services
//Configurre the Custom User and Role Class
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(
    options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredUniqueChars = 4;
        // Other settings can be configured here
    })
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Configure the Application Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    // If the LoginPath isn't set, ASP.NET Core defaults the path to /Account/Login.
    options.LoginPath = "/Account/Login"; // Set your login path here
});
//builder.services.addwebsocketmanager();

builder.Services.AddTransient<ConnectionManager>();
builder.Services.AddSingleton<ChatHandler>();


var app = builder.Build();

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromSeconds(120),
    ReceiveBufferSize = 4 * 1024
};
app.UseWebSockets(webSocketOptions);
var handler = app.Services.GetRequiredService<ChatHandler>();
app.UseMiddleware<WebSocketMiddleware>(handler);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//Configuring Authentication Middleware to the Request Pipeline
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

