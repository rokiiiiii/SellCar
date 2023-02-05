using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class AdsRepository : GenericRepository<Ads, DbContextSellCar>, IAdsRepository
    {

        public List<Ads> Filter(string url, string min_price, string max_price, string min_kregionometers, string max_kregionometers, string min_year, string max_year, string[] fuel_type, string[] gear_type, string[] body_type, string min_horse, string max_horse, string[] traction, string[] color, string from_who, string status, string swap, string[] region)
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
                if (!string.IsNullOrEmpty(min_price))
                {
                    ads = ads.Where(i => i.Price > Convert.ToDouble(min_price));
                }
                if (!string.IsNullOrEmpty(max_price))
                {
                    ads = ads.Where(i => i.Price < Convert.ToDouble(max_price));
                }
                if (!string.IsNullOrEmpty(min_kregionometers))
                {
                    ads = ads.Where(i => i.Mileage > Convert.ToInt32(min_kregionometers));
                }
                if (!string.IsNullOrEmpty(max_kregionometers))
                {
                    ads = ads.Where(i => i.Mileage < Convert.ToInt32(max_kregionometers));
                }
                if (!string.IsNullOrEmpty(min_year))
                {
                    ads = ads.Where(i => i.year > Convert.ToInt32(min_year));
                }
                if (!string.IsNullOrEmpty(max_year))
                {
                    ads = ads.Where(i => i.year < Convert.ToInt32(max_year));
                }
                if (!string.IsNullOrEmpty(min_horse))
                {
                    ads = ads.Where(i => i.MotorPower > Convert.ToInt32(min_horse));
                }
                if (!string.IsNullOrEmpty(max_horse))
                {
                    ads = ads.Where(i => i.MotorPower < Convert.ToInt32(max_horse));
                }
                if (region.Length != 0)
                {
                    ads = ads.Where(i => region.Contains(i.Region.Name));
                }
                if (color.Length != 0)
                {
                    ads = ads.Where(i => color.Contains(i.Color));

                }
                if (traction.Length != 0)
                {
                    ads = ads.Where(i => traction.Contains(i.TractionType));

                }
                if (fuel_type.Length != 0)
                {
                    ads = ads.Where(i => fuel_type.Contains(i.FuelType));

                }
                if (gear_type.Length != 0)
                {
                    ads = ads.Where(i => gear_type.Contains(i.GearType));

                }
                if (body_type.Length != 0)
                {
                    ads = ads.Where(i => body_type.Contains(i.BodyType));

                }
                if (!string.IsNullOrEmpty(swap))
                {
                    ads = ads.Where(i => i.Swap == swap);
                }
                if (!string.IsNullOrEmpty(from_who))
                {
                    ads = ads.Where(i => i.FromWho == from_who);
                }
                if (!string.IsNullOrEmpty(status))
                {
                    ads = ads.Where(i => i.Status == status);
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
                    .Include(i => i.Brand)
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
                    .Include(i => i.Brand)
                     .Include(i => i.Region)
                    .FirstOrDefault(i => i.RegionId == id);
            }
        }
        public List<Ads> GetPost(string url)
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
