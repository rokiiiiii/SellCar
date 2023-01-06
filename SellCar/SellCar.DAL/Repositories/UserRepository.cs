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
    public class UserRepository : IUserRepository
    {
        private readonly DbContextSellCar _db;

        public UserRepository(DbContextSellCar db)
        {
            _db = db;
        }

        public async Task<bool> Create(User entity)
        {
            await _db.AddAsync(entity);
            return true;
            
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Remove(entity);
           return true;
        }

        public async Task<User> Get(int id)
        {
            return await _db.User.FirstOrDefaultAsync(x=> x.id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _db.User.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<User>> Select()
        {
            return await _db.User.ToListAsync();
        }
    }
}
