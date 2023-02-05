using SellCar.Domain.Models;

namespace SellCar.Service.Intrefaces
{
    public interface IFavoriteService
    {
        void Create(Favorite entity);
        void Update(Favorite entity);
        void Delete(Favorite entity);
        Favorite GetById(int id);
        List<Favorite> GetFavByUserId(string userId);
    }
}
