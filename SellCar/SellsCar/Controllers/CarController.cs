using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SellCar.Domain.Identity;
using SellCar.Domain.ViewModels.Ad;
using SellCar.Domain.ViewModels.Users;
using SellCar.Service.Intrefaces;

namespace SellsCar.Web.Controllers
{
    public class CarController : Controller
    {
        private IAdsService _adsService;
        private IRegionService _regionService;
        private IFavoriteService _favoriteService;
        private UserManager<User> _user;

        public CarController(IAdsService adsService, IRegionService regionService, IFavoriteService favoriteService, UserManager<User> user)
        {
            _adsService = adsService;
            _regionService = regionService;
            _favoriteService = favoriteService;
            _user = user;
        }

        [HttpGet]
        public IActionResult List(string url)
        {
            var model = new AdsListViewModel()
            {
                Ads = _adsService.GetPost(url),
            };
            ViewBag.CarUrl = (RouteData.Values["url"] == null) ? "" : RouteData.Values["url"];
            ViewBag.Region = _regionService.GetRegion();
            return View(model);
        }
        [HttpPost]
        public IActionResult List(string url, string MinPrice, string MaxPrice, string MinMileage, string MaxMileage, string min_year, string MaxYear, string[] FuelType, string[] GearType, string[] BodyType, string MinHorse, string MaxHorse, string[] Traction, string[] Color, string FromWho, string Status, string Swap, string[] Region)
        {
            var model = new AdsListViewModel()
            {
                Ads = _adsService.Filter(url, MinPrice, MaxPrice, MinMileage, MaxMileage, min_year, MaxYear, FuelType, GearType, BodyType, MinHorse, MaxHorse, Traction, Color, FromWho, Status, Swap, Region),
                FuelType = FuelType,
                GearType = GearType,
                BodyType = BodyType,
                Traction = Traction,
                Color = Color,
                MinPrice = MinPrice,
                MaxPrice = MaxPrice,
                MinMileage = MinMileage,
                MaxMileage = MaxMileage,
                MinYear= min_year,
                MaxYear = MaxYear,
                MinHorse = MinMileage,
                MaxHorse = MinMileage,
                FromWho = MinMileage,
                Status = Status,
                Swap = Swap,
                Region = Region,
            };
            ViewBag.CarUrl = RouteData.Values["url"];
            ViewBag.Region = _regionService.GetRegion();

            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var ads = _adsService.GetAdDetail((int)id);
            var user = await _user.FindByIdAsync(ads.UserId);

            var favorite = _favoriteService.GetFavByUserId(_user.GetUserId(User));
            if (id == null)
            {
                return NotFound();
            }
            var model = new AdsDetailViewModel()
            {
                ads = ads,
                user = user,
                AdPicture = ads.PostingPictures,
                AddFavorites = favorite.Any(i => i.AdsId == id)
            };
            return View(model);
        }
        public async Task<IActionResult> UserAds(string id)
        {
            var ads = _adsService.GetPost("").Where(i => i.UserId == id).ToList();
            var user = await _user.FindByIdAsync(id);
            var model = new UserAdsListViewModel()
            {
                Ads = ads,
                User = user,
            };
            return View(model);
        }
    }
}

