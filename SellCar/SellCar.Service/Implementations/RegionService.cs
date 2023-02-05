using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;

namespace SellCar.Service.Implementations
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _IRegionRepository;

        public RegionService(IRegionRepository iRegionRepository)
        {
            _IRegionRepository = iRegionRepository;
        }

        public void Create(Region entity)
        {
            _IRegionRepository.Create(entity);
        }

        public void Delete(Region entity)
        {
            _IRegionRepository.Delete(entity);
        }

        public Region MostAdvertisedRegion()
        {
            return _IRegionRepository.MostAdvertisedRegion();
        }

        public Region LeastAnnouncedRegion()
        {
            return _IRegionRepository.LeastAnnouncedRegion();
        }

        public Region GetById(int id)
        {
            return _IRegionRepository.GetById(id);
        }

        public Region GetByIdWithPosts(int ilId)
        {
            return _IRegionRepository.GetByIdWithPosts(ilId);
        }

        public List<Region> GetRegion()
        {
            return _IRegionRepository.GetRegion();
        }

        public void Update(Region entity)
        {
            _IRegionRepository.Update(entity);
        }
    }
}
