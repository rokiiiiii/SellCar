using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using SellCar.DAL;
using SellCar.Domain.Identity;
using SellsCar.DAL;
using SellsCar.Web;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<DbContextSellCar>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarContext") ?? throw new InvalidOperationException("Connection string 'SellCarString' not found.")));
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarContext") ?? throw new InvalidOperationException("Connection string 'SellCarString' not found.")));

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
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(

name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


app.UseEndpoints(endpoints =>
{
    //user
    endpoints.MapControllerRoute(
        name: "adminuser",
        pattern: "admin/user/list",
        defaults: new { controller = "Admin", action = "UserList" }
    );
    endpoints.MapControllerRoute(
        name: "adminuseredit",
        pattern: "admin/user/{id?}",
        defaults: new { controller = "Admin", action = "UserEdit" }
    );
    endpoints.MapControllerRoute(
        name: "adminuserdelete",
        pattern: "admin/users/delete",
        defaults: new { controller = "Admin", action = "UserDelete" }
    );
    //role
    endpoints.MapControllerRoute(
        name: "adminrole",
        pattern: "admin/role/list",
        defaults: new { controller = "Admin", action = "RoleList" }
    );
    endpoints.MapControllerRoute(
        name: "adminrolecreate",
        pattern: "admin/role/create",
        defaults: new { controller = "Admin", action = "RoleCreate" }
    );
    endpoints.MapControllerRoute(
        name: "adminroleedit",
        pattern: "admin/role/{id?}",
        defaults: new { controller = "Admin", action = "RoleEdit" }
    );
    endpoints.MapControllerRoute(
        name: "adminroledelete",
        pattern: "admin/roles/delete",
        defaults: new { controller = "Admin", action = "RoleDelete" }
    );
    //car
    endpoints.MapControllerRoute(
        name: "admincar",
        pattern: "admin/car/list",
        defaults: new { controller = "Admin", action = "CarList" }
    );
    endpoints.MapControllerRoute(
        name: "admincarcreate",
        pattern: "admin/car/create",
        defaults: new { controller = "Admin", action = "CarCreate" }
    );
    endpoints.MapControllerRoute(
        name: "admincaredit",
        pattern: "admin/car/{id?}",
        defaults: new { controller = "Admin", action = "CarEdit" }
    );
    endpoints.MapControllerRoute(
        name: "admincardelete",
        pattern: "admin/cars/delete",
        defaults: new { controller = "Admin", action = "CarDelete" }
    );
    //region
    endpoints.MapControllerRoute(
        name: "adminregion",
        pattern: "admin/region/list",
        defaults: new { controller = "Admin", action = "RegionList" }
    );
    endpoints.MapControllerRoute(
        name: "adminregioncreate",
        pattern: "admin/region/create",
        defaults: new { controller = "Admin", action = "RegionCreate" }
    );
    //endpoints.MapControllerRoute(
    //    name: "adminiledit",
    //    pattern: "admin/region/{id?}",
    //    defaults: new { controller = "Admin", action = "RegionEdit" }
    //);
    endpoints.MapControllerRoute(
        name: "adminildelete",
        pattern: "admin/region/delete",
        defaults: new { controller = "Admin", action = "RegionDelete" }
    );
    //ads
    endpoints.MapControllerRoute(
        name: "adminads",
        pattern: "admin/ads/list",
        defaults: new { controller = "Admin", action = "AdList" }
    );
    endpoints.MapControllerRoute(
        name: "adminadsdelete",
        pattern: "admin/ad/delete",
        defaults: new { controller = "Admin", action = "AdsDelete" }
    );
    endpoints.MapControllerRoute(
        name: "adminadsedit",
        pattern: "admin/ad/{id?}",
        defaults: new { controller = "Admin", action = "AdsEdit" }
    );

    //UserAd
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
    //UserFavorite
    endpoints.MapControllerRoute(
        name: "userfavorite",
        pattern: "user/favorites",
        defaults: new { controller = "User", action = "FavoriteAds" }
    );

});
app.Run();
