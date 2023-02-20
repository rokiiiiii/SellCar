using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Service.Intrefaces;
using System;

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
        public List<Ads> Filter(string url, string MinPrice, string MaxPrice, string MinMileage, string MaxMileage, string min_year, string MaxYear, string[] FuelType, string[] GearType, string[] BodyType, string MinHorse, string MaxHorse, string[] Traction, string[] Color, string FromWho, string Status, string Swap, string[] Region)
        {
            return _adsRepository.Filter(url, MinPrice, MaxPrice, MinMileage, MaxMileage, min_year, MaxYear, FuelType, GearType, BodyType, MinHorse, MaxHorse, Traction, Color, FromWho, Status, Swap, Region);
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
