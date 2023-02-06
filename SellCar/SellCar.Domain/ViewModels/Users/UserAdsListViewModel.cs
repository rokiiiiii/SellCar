using SellCar.Domain.Identity;
using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Users
{
    public class UserAdsListViewModel
    {
        public List<Ads> Ads { get; set; }
        public User User { get; set; }
    }
}
