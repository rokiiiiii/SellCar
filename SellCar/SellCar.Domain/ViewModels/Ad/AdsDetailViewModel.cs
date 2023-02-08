using SellCar.Domain.Identity;
using SellCar.Domain.Models;

namespace SellCar.Domain.ViewModels.Ad
{
    public class AdsDetailViewModel
    {
        public Ads ads { get; set; }
        public User user { get; set; }
        public bool AddFavorites { get; set; }
        public List<Picture> AdPicture { get; set; }
    }
}
