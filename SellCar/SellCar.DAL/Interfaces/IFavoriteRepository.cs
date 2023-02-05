using SellCar.Domain.Models;

namespace SellCar.DAL.Interfaces
{
    public interface IFavoriteRepository : IBaseRepository<Favorite>
    {
        List<Favorite> GetFavByUserId(string userId);
    }
}
