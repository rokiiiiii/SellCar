using SellCar.Domain.Models;

namespace SellCar.DAL.Interfaces
{
    public interface IAdsRepository : IBaseRepository<Ads>
    {
        List<Ads> GetHomePosts();
        List<Ads> GetPost(string url);
        Ads GetAdDetail(int id);
        List<Ads> GetSearchResult(string searchString);
        List<Ads> Filter(string url, string minPrice, string maxPrice, string minMileage, string maxMileage, string min_year, string maxYear, string[] fuelType, string[] gearType, string[] bodyType, string minHorse, string maxHorse, string[] traction, string[] color, string fromWho, string status, string swap, string[] region);
    }
}
