using SellCar.Domain.Identity;
using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Ad
{
    public class AdsDetailViewModel
    {
        public Ads Ads { get; set; }
        public User User { get; set; }
        public bool AddFavorites { get; set; }
        public List<Picture> AdPicture { get; set; }
    }
}
