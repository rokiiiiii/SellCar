using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SellCar.Domain.Models;
using SellCar.DAL;
using SellCar.DAL.Interfaces;
using SellCar.DAL.Repositories;
using SellsCar.DAL;
using SellCar.Service.Intrefaces;
using SellCar.Service.Implementations;
using Microsoft.AspNetCore.Authentication.Cookies;
using SellsCar.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<DbContextSellCar>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarWebContext") ?? throw new InvalidOperationException("Connection string 'SellsCarWebContext' not found.")));


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.InitializeRepositories();
builder.Services.InitializeServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
