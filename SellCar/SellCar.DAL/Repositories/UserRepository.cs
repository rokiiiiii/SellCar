using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SellCar.DAL.Repositories
{
    public class UserRepository :IBaseRepository<User>
    {
        private readonly DbContextSellCar _db;

        public UserRepository(DbContextSellCar db)
        {
            _db = db;
        }

        public IQueryable<User> GetAll()
        {
            return _db.User;
        }

        public async Task Delete(User entity)
        {
            _db.User.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(User entity)
        {
            await _db.User.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Update(User entity)
        {
            _db.User.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        
    }
    }
}
