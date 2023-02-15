
using Microsoft.AspNetCore.Identity;
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
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DbContextSellCar>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarWebContext") ?? throw new InvalidOperationException("Connection string 'SellsCarWebContext' not found.")));
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarWebContext") ?? throw new InvalidOperationException("Connection string 'SellsCarWebContext' not found.")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    // Lockout                
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    // options.User.AllowedUserNameCharacters = "";
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
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
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "UserAdsEdit",
        pattern: "{controller=User}/{action=EditAds}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "userads",
        pattern: "user/ad",
        defaults: new { controller = "User", action = "Ads" }
    );
    endpoints.MapControllerRoute(
        name: "search",
        pattern: "search",
        defaults: new { controller = "Home", action = "Search" }
    );
    endpoints.MapControllerRoute(
        name: "cars",
        pattern: "cars/{url?}",
        defaults: new { controller = "Car", action = "List" }
    );

});

app.Run();
