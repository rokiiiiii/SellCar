using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SellCar.Domain.Models;

namespace SellsCar.DAL
{
    public class DbContextSellCar : DbContext
    {
        public DbContextSellCar(DbContextOptions<DbContextSellCar> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Car> Car { get; set; }
    }
}
