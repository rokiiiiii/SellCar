using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class AdsRepository : GenericRepository<Ads, DbContextSellCar>, IAdsRepository
    {

        public List<Ads> Filter(string url, string minPrice, string maxPrice, string minMileage, string maxMileage, string minYear, string maxYear, string[] fuelType, string[] gearType, string[] bodyType, string minHorse, string maxHorse, string[] Traction, string[] Color, string fromWho, string Status, string Swap, string[] Region)
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
                if (!string.IsNullOrEmpty(minPrice))
                {
                    ads = ads.Where(i => i.Price > Convert.ToDouble(minPrice));
                }
                if (!string.IsNullOrEmpty(maxPrice))
                {
                    ads = ads.Where(i => i.Price < Convert.ToDouble(maxPrice));
                }
                if (!string.IsNullOrEmpty(minMileage))
                {
                    ads = ads.Where(i => i.Mileage > Convert.ToInt32(minMileage));
                }
                if (!string.IsNullOrEmpty(maxMileage))
                {
                    ads = ads.Where(i => i.Mileage < Convert.ToInt32(maxMileage));
                }
                if (!string.IsNullOrEmpty(minYear))
                {
                    ads = ads.Where(i => i.Year > Convert.ToInt32(minYear));
                }
                if (!string.IsNullOrEmpty(maxYear))
                {
                    ads = ads.Where(i => i.Year < Convert.ToInt32(maxYear));
                }
                if (!string.IsNullOrEmpty(minHorse))
                {
                    ads = ads.Where(i => i.MotorPower > Convert.ToInt32(minHorse));
                }
                if (!string.IsNullOrEmpty(maxHorse))
                {
                    ads = ads.Where(i => i.MotorPower < Convert.ToInt32(maxHorse));
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
                if (fuelType.Length != 0)
                {
                    ads = ads.Where(i => fuelType.Contains(i.FuelType));

                }
                if (gearType.Length != 0)
                {
                    ads = ads.Where(i => gearType.Contains(i.GearType));

                }
                if (bodyType.Length != 0)
                {
                    ads = ads.Where(i => bodyType.Contains(i.BodyType));

                }
                if (!string.IsNullOrEmpty(Swap))
                {
                    ads = ads.Where(i => i.Swap == Swap);
                }
                if (!string.IsNullOrEmpty(fromWho))
                {
                    ads = ads.Where(i => i.FromWho == fromWho);
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

        public List<Ads> GetSearchResult(string? searchString)
        {
            if (searchString != null)
            {
                using (var context = new DbContextSellCar())
                {
                    var ads = context
                        .Ads
                        .Include(i => i.Car)
                        .Include(i => i.PostingPictures)
                        .Where(i => (i.Title.ToLower().Contains(searchString.ToLower())
                                     || /* i.region.ToLower().Contains(searchString.ToLower()) ||*/
                                     i.Status.ToLower().Contains(searchString.ToLower())
                                     || i.Model.ToLower().Contains(searchString.ToLower())
                                     || i.BodyType.ToLower().Contains(searchString.ToLower())
                                     || i.Car.Name.ToLower().Contains(searchString.ToLower())
                                     || i.FromWho.ToLower().Contains(searchString.ToLower())
                                     || i.Color.ToLower().Contains(searchString.ToLower())
                                     || i.GearType.ToLower().Contains(searchString.ToLower())
                                     || i.FuelType.ToLower().Contains(searchString.ToLower())
                                     || i.TractionType.ToLower().Contains(searchString.ToLower())
                            ))
                        .AsQueryable();
                    return ads.ToList();
                }

            }
            else
            {
                return new List<Ads>();
            }
        }

    }
}
