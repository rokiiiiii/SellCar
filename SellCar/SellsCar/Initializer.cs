using SellCar.DAL.Interfaces;
using SellCar.DAL.Repositories;
using SellCar.Domain.Models;
using SellCar.Service.Implementations;
using SellCar.Service.Intrefaces;
using System.Configuration;

namespace SellsCar.Web
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdsRepository, AdsRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAdsService, AdsService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IRegionService, RegionService>();

        }
    }
}
