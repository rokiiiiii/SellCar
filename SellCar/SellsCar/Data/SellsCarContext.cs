using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SellsCar.DbModels;

namespace SellsCar.Data
{
    public class SellsCarContext : DbContext
    {
        public SellsCarContext (DbContextOptions<SellsCarContext> options)
            : base(options)
        {
        }

        public DbSet<SellsCar.DbModels.User> User { get; set; } = default!;

        public DbSet<SellsCar.DbModels.Car> Car { get; set; }

        public DbSet<SellsCar.DbModels.Ads> Ads { get; set; }
    }
}
