using Microsoft.EntityFrameworkCore;
using SellCar.Domain.Identity;
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

        public DbContextSellCar()
        {
            
        }

        public DbContextSellCar(DbContextOptions<DbContextSellCar> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL8004.site4now.net;Initial Catalog=db_a95722_sellcardb;User Id=db_a95722_sellcardb_admin;Password=14102003r",
                builder =>builder.EnableRetryOnFailure());

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
