using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using SellCar.DAL;
using SellCar.Domain.Identity;
using SellsCar.DAL;
using SellsCar.Web;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DbContextSellCar>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarWebContext") ?? throw new InvalidOperationException("Connection string 'SellsCarWebContext' not found.")));


builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DbContextSellCar>().AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/account/login";
        options.LogoutPath = "/account/logout";
        options.AccessDeniedPath = "/account/accessdenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.Cookie = new CookieBuilder
        {
            HttpOnly = true,
            Name = ".SellCar.Security.Cookie",
            SameSite = SameSiteMode.Strict
        };
    });

builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    SeedDb.Seed();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
