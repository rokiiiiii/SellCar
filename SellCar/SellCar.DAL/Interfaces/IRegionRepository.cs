using SellCar.Domain.Models;

namespace SellCar.DAL.Interfaces
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
        List<Region> GetRegion();
        public Region GetByIdWithPosts(int RegionId);
        public Region MostAdvertisedRegion();
        public Region LeastAnnouncedRegion();

    }
}
