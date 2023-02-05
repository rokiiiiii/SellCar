using Microsoft.EntityFrameworkCore;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite, DbContextSellCar>, IFavoriteRepository
    {
        public List<Favorite> GetFavByUserId(string userId)
        {
            using (var context = new DbContextSellCar())
            {
                return context.Favorite
                    .Where(i => i.UserId == userId)
                    .Include(i => i.Ads)
                    .Include(i => i.Ads.PostingPictures)
                    .Include(i => i.Ads.Car)
                    .ToList();
            }
        }
    }
}
