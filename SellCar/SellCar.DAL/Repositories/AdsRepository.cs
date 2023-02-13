using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class AdsRepository : GenericRepository<Ads, DbContextSellCar>, IAdsRepository
    {

        public List<Ads> Filter(string url, string MinPrice, string MaxPrice, string MinMileage, string MaxMileage, string MinYear, string MaxYear, string[] FuelType, string[] GearType, string[] BodyType, string MinHorse, string MaxHorse, string[] Traction, string[] Color, string FromWho, string Status, string Swap, string[] Region)
        {
            using (var context = new DbContextSellCar())
            {
                var ads = context.Ads
                    .Include(i => i.Brand)
                    .Include(i => i.PostingPictures)
                    .Include(i => i.Region)
                    .ToList().AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    ads = ads
                        .Include(i => i.Brand)
                        .Include(i => i.PostingPictures)
                        .Where(i => i.Car.Url == url);
                }
                if (!string.IsNullOrEmpty(MinPrice))
                {
                    ads = ads.Where(i => i.Price > Convert.ToDouble(MinPrice));
                }
                if (!string.IsNullOrEmpty(MaxPrice))
                {
                    ads = ads.Where(i => i.Price < Convert.ToDouble(MaxPrice));
                }
                if (!string.IsNullOrEmpty(MinMileage))
                {
                    ads = ads.Where(i => i.Mileage > Convert.ToInt32(MinMileage));
                }
                if (!string.IsNullOrEmpty(MaxMileage))
                {
                    ads = ads.Where(i => i.Mileage < Convert.ToInt32(MaxMileage));
                }
                if (!string.IsNullOrEmpty(MinYear))
                {
                    ads = ads.Where(i => i.year > Convert.ToInt32(MinYear));
                }
                if (!string.IsNullOrEmpty(MaxYear))
                {
                    ads = ads.Where(i => i.year < Convert.ToInt32(MaxYear));
                }
                if (!string.IsNullOrEmpty(MinHorse))
                {
                    ads = ads.Where(i => i.MotorPower > Convert.ToInt32(MinHorse));
                }
                if (!string.IsNullOrEmpty(MaxHorse))
                {
                    ads = ads.Where(i => i.MotorPower < Convert.ToInt32(MaxHorse));
                }
                if (Region.Length != 0)
                {
                    ads = ads.Where(i => Region.Contains(i.Region.Name));
                }
                if (Color.Length != 0)
                {
                    ads = ads.Where(i => Color.Contains(i.Color));

                }
                if (Traction.Length != 0)
                {
                    ads = ads.Where(i => Traction.Contains(i.TractionType));

                }
                if (FuelType.Length != 0)
                {
                    ads = ads.Where(i => FuelType.Contains(i.FuelType));

                }
                if (GearType.Length != 0)
                {
                    ads = ads.Where(i => GearType.Contains(i.GearType));

                }
                if (BodyType.Length != 0)
                {
                    ads = ads.Where(i => BodyType.Contains(i.BodyType));

                }
                if (!string.IsNullOrEmpty(Swap))
                {
                    ads = ads.Where(i => i.Swap == Swap);
                }
                if (!string.IsNullOrEmpty(FromWho))
                {
                    ads = ads.Where(i => i.FromWho == FromWho);
                }
                if (!string.IsNullOrEmpty(Status))
                {
                    ads = ads.Where(i => i.Status == Status);
                }

                return ads.ToList();

            }
        }
        public List<Ads> GetHomePosts()
        {
            using (var context = new DbContextSellCar())
            {
                return context.Ads
                    .Where(i => i.HomePage == true)
                    .Include(i => i.Car)
                    .Include(i => i.PostingPictures)
                    .ToList();
            }
        }
        public Ads GetAdDetail(int id)
        {
            using (var context = new DbContextSellCar())
            {
                return context.Ads
                    .Include(i => i.PostingPictures)
                    .Include(i => i.Car)
                    .Include(i => i.Region)
                    .FirstOrDefault(i => i.AdsId == id);
            }
        }
        public List<Ads> GetPost(string url)
        {
            using (var context = new DbContextSellCar())
            {
                var ads = context.Ads
                       .Include(i => i.Car)
                       .Include(i => i.PostingPictures)
                        .Include(i => i.Region)
                       .ToList().AsQueryable();

                if (!string.IsNullOrEmpty(url))
                {
                    ads = ads
                        .Include(i => i.Car)
                        .Include(i => i.PostingPictures)
                        .Where(i => i.Car.Url == url);
                }
                return ads.ToList();
            }
        }
        public List<Ads> GetSearchResult(string searchString)
        {
            using (var context = new DbContextSellCar())
            {
                var ads = context
                    .Ads
                    .Include(i => i.Brand)
                    .Include(i => i.PostingPictures)
                    .Where(i => (i.title.ToLower().Contains(searchString.ToLower()) ||/* i.region.ToLower().Contains(searchString.ToLower()) ||*/ i.Status.ToLower().Contains(searchString.ToLower()) || i.BodyType.ToLower().Contains(searchString.ToLower())
                    || i.Car.Name.ToLower().Contains(searchString.ToLower()) || i.FromWho.ToLower().Contains(searchString.ToLower()) || i.Color.ToLower().Contains(searchString.ToLower()) || i.GearType.ToLower().Contains(searchString.ToLower())
                    || i.FuelType.ToLower().Contains(searchString.ToLower()) || i.TractionType.ToLower().Contains(searchString.ToLower())
                    ))
                    .AsQueryable();

                return ads.ToList();
            }
        }

    }
}
