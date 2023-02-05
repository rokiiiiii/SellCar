using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;

namespace SellCar.Service.Implementations
{
    public class FavoriteService : IFavoriteService
    {
        private IFavoriteRepository _FavoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _FavoriteRepository = favoriteRepository;
        }

        public void Create(Favorite entity)
        {
            _FavoriteRepository.Create(entity);
        }
        public void Update(Favorite entity)
        {
            _FavoriteRepository.Update(entity);
        }
        public void Delete(Favorite entity)
        {
            _FavoriteRepository.Delete(entity);
        }

        public Favorite GetById(int id)
        {
            return _FavoriteRepository.GetById(id);
        }
        public List<Favorite> GetFavByUserId(string userId)
        {
            return _FavoriteRepository.GetFavByUserId(userId);
        }
    }
}
