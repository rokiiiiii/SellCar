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
        List<Ads> Filter(string url, string minPrice, string maxPrice, string minMileage, string maxMileage, string minYear, string maxYear, string[] FuelType, string[] GearType, string[] BodyType, string minHorse, string maxHorse, string[] Traction, string[] Color, string FromWho, string Status, string Swap, string[] Region);
        List<Ads> GetSearchResult(string searchString);

    }
}
