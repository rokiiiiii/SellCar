using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SellCar.Domain.Models;
using SellCar.DAL;
using SellCar.DAL.Interfaces;
using SellCar.DAL.Repositories;
using SellsCar.DAL;
using SellCar.Service.Intrefaces;
using SellCar.Service.Implementations;
 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContextSellCar>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellsCarWebContext") ?? throw new InvalidOperationException("Connection string 'SellsCarWebContext' not found.")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
