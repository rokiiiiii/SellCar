using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class CarRepository :IBaseRepository<Car>
    {
        private readonly DbContextSellCar _db;


        public CarRepository(DbContextSellCar db)
        {
            _db = db;
            _db.Dispose();
        }

        public async Task Create(Car entity)
        {
            await _db.Car.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Car> GetAll()
        {
            return _db.Car;
        }

        public async Task Delete(Car entity)
        {
            _db.Car.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Car> Update(Car entity)
        {
            _db.Car.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}



