using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellsCar.DAL;

namespace SellCar.DAL.Repositories
{
    public class PictureRepository : GenericRepository<Picture, DbContextSellCar>, IPictureRepository
    {
        public Picture GetByUrl(string url)
        {
            using (var context = new DbContextSellCar())
            {
                return context.Picture.Where(i => i.Url == url)
                    .FirstOrDefault();
            }
        }
    }
}
