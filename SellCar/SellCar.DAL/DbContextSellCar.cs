using Microsoft.EntityFrameworkCore;
using SellCar.Domain.Models;


namespace SellsCar.DAL
{
    public class DbContextSellCar : DbContext
    {
<<<<<<< Updated upstream
=======
        public DbContextSellCar(DbContextOptions<DbContextSellCar> options)
            : base(options)
        {
           
        }
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            optionsBuilder.UseSqlite("Data Source=Db");
=======

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SellsCar.Web.Data;Trusted_Connection=True;MultipleActiveResultSets=true");
>>>>>>> Stashed changes
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
