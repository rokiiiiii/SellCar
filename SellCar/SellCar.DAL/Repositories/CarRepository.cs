using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class CarRepository : GenericRepository<Car, DbContextSellCar>, ICarRepository
    {
        public Car GetByIdWithPosts(int markaId)
        {
            using (var context = new DbContextSellCar())
            {
                return context.Car
                    .Where(i => i.CarId == markaId)
                    .Include(i => i.Ads)
                    .ThenInclude(i => i.Region)
                    .FirstOrDefault();

            }
        }
        public List<Car> GetCars()
        {
            using (var context = new DbContextSellCar())
            {
                return context.Car
                    .Include(i => i.Ads)
                    .OrderBy(i => i.Name)
                    .ToList();
            }
        }
    }
}



