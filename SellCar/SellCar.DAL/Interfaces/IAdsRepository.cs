using SellCar.Domain.Models;

namespace SellCar.DAL.Interfaces
{
    public interface IAdsRepository : IBaseRepository<Ads>
    {
        List<Ads> GetHomePosts();
        List<Ads> GetPost(string url);
        Ads GetAdDetail(int id);
        List<Ads> Filter(string url, string MinPrice, string MaxPrice, string MinMileage, string MaxMileage, string min_year, string MaxYear, string[] FuelType, string[] GearType, string[] BodyType, string MinHorse, string MaxHorse, string[] Traction, string[] Color, string FromWho, string Status, string Swap, string[] Region);
        List<Ads> GetSearchResult(string searchString);
    }
}
