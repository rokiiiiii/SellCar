using Microsoft.EntityFrameworkCore;
using SellCar.Domain.Enum;
using SellCar.Domain.Helpers;
using SellCar.Domain.Models;


namespace SellsCar.DAL
{
    public class DbContextSellCar : DbContext
    {
        public DbContextSellCar(DbContextOptions<DbContextSellCar> options)
            : base(options)
        {

        }
        public DbSet<Car> Car { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Ads> Ads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User").HasKey(x => x.Id);

                builder.HasData(new User
                {
                    Id = 1,
                    Name = "rokimile",
                    Password = HashPasswordHelper.HashPassowrd("123456"),
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Car>(builder =>
            {
                builder.ToTable("Car").HasKey(x => x.Id);

                builder.HasData(new Car
                {
                    Id = 1,
                    Brand = "Toyota",
                    Model = "Gt 86",
                    YearCreate = DateTime.Now,
                    HoursPower = 200,
                    TypeCar = TypeCar.Hatchback
                });
            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();


                builder.HasData(new Profile()
                {
                    Id = 1,
                    UserId = 1
                });
            });

        }
    }
}
