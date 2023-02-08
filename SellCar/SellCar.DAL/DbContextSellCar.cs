using Microsoft.EntityFrameworkCore;
using SellCar.Domain.Models;


namespace SellsCar.DAL
{
    public class DbContextSellCar : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Favorite> Favorite { get; set; }


        public DbContextSellCar(DbContextOptions<DbContextSellCar> options)
           : base(options)
        {

        }

        public DbContextSellCar()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Db");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
