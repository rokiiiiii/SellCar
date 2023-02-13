using SellCar.Domain.Models;

namespace SellCar.Service.Intrefaces
{
    public interface IAdsService
    {
        void Create(Ads entity);
        void Update(Ads entity);
        void Delete(Ads entity);
        Ads GetById(int id);
        List<Ads> GetHomePosts();
        List<Ads> GetPost(string url);
        Ads GetAdDetail(int id);
        List<Ads> Filter(string url, string MinPrice, string MaxPrice, string MinMileage, string MaxMileage, string min_year, string MaxYear, string[] FuelType, string[] GearType, string[] BodyType, string MinHorse, string MaxHorse, string[] Traction, string[] Color, string FromWho, string Status, string Swap, string[] Region);
        List<Ads> GetSearchResult(string searchString);
    }
}
