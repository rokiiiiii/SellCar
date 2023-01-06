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

        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select()
        {
            throw new NotImplementedException();
        }
    }
}
