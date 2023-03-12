using Microsoft.Extensions.Logging;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;

namespace SellCar.Service.Implementations
{
    public class AdsService : IAdsService
    {
        private IAdsRepository _adsRepository;
        private readonly ILogger<AdsService> _logger;

        public AdsService(IAdsRepository adsRepository, ILogger<AdsService> logger)
        {
            _adsRepository = adsRepository;
            _logger = logger;
        }

        public void Create(Ads entity)
        {
            _adsRepository.Create(entity);
        }
        public void Update(Ads entity)
        {
            _adsRepository.Update(entity);
        }
        public void Delete(Ads entity)
        {
            _adsRepository.Delete(entity);
        }
        public List<Ads> Filter(string url, string minPrice, string maxPrice, string minMileage, string maxMileage, string minYear, string maxYear, string[] fuelType, string[] gearType, string[] bodyType, string minHorse, string maxHorse, string[] Traction, string[] Color, string fromWho, string Status, string Swap, string[] Region)
        {
            return _adsRepository.Filter(url, minPrice, maxPrice, minMileage, maxMileage, minYear, maxYear, fuelType, gearType, bodyType, minHorse, maxHorse, Traction, Color, fromWho, Status, Swap, Region);
        }

        public List<Ads> GetHomePosts()
        {
            return _adsRepository.GetHomePosts();
        }
        public Ads GetById(int id)
        {
            return _adsRepository.GetById(id);
        }
        public Ads GetAdDetail(int id)
        {
            return _adsRepository.GetAdDetail(id);
        }
        public List<Ads> GetPost(string url)
        {
            return _adsRepository.GetPost(url);
        }
        public List<Ads> GetSearchResult(string searchString)
        {
            return _adsRepository.GetSearchResult(searchString);
        }
    }
}
