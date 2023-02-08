using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;

namespace SellCar.Service.Implementations
{
    public class AdsService : IAdsService
    {
        private IAdsRepository _adsRepository;

        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
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
        public List<Ads> Filter(string url, string min_price, string max_price, string min_kilometers, string max_kilometers, string min_year, string max_year, string[] fuel_type, string[] gear_type, string[] body_type, string min_horse, string max_horse, string[] traction, string[] color, string from_who, string status, string trade_in, string[] region)
        {
            return _adsRepository.Filter(url, min_price, max_price, min_kilometers, max_kilometers, min_year, max_year, fuel_type, gear_type, body_type, min_horse, max_horse, traction, color, from_who, status, trade_in, region);
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
