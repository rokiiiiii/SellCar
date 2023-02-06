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
        List<Ads> Filter(string url, string min_price, string max_price, string min_kilometers, string max_kilometers, string min_year, string max_year, string[] fuel_type, string[] gear_type, string[] body_type, string min_horse, string max_horse, string[] traction, string[] color, string from_who, string status, string trade_in, string[] region);
        List<Ads> GetSearchResult(string searchString);
    }
}
