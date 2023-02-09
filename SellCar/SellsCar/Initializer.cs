using SellCar.DAL.Interfaces;
using SellCar.DAL.Repositories;
using SellCar.Domain.Models;
using SellCar.Service.Implementations;
using SellCar.Service.Interfaces;
using SellCar.Service.Intrefaces;

namespace SellsCar.Web
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Car>, CarRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
           
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();     
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAccountService, AccountService>();

        }
    }
}
