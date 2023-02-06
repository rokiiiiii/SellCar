
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using SellCar.DAL;
using SellCar.Domain.Identity;
using SellsCar.DAL;
using SellsCar.Web;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=Db"));
builder.Services.AddDbContext<DbContextSellCar>(options => options.UseSqlite("Data Source=Db"));

builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

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


SeedDb.Seed();
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
