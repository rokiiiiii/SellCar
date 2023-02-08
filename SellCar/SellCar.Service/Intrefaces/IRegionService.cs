using SellCar.Domain.Models;

namespace SellCar.Service.Intrefaces
{
    public interface IRegionService
    {
        void Create(Region entity);
        void Update(Region entity);
        void Delete(Region entity);
        Region GetById(int id);
        List<Region> GetRegion();
        Region GetByIdWithPosts(int ilId);
        Region MostAdvertisedRegion();
        Region LeastAnnouncedRegion();
    }
}
