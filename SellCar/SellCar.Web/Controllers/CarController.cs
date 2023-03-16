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
        public IActionResult List(string url, string minPrice, string maxPrice, string minMileage, string maxMileage, string minYear, string maxYear, string[] fuelType, string[] gearType, string[] bodyType, string minHorse, string maxHorse, string[] Traction, string[] Color, string fromWho, string Status, string Swap, string[] Region)
        {
            var model = new AdsListViewModel()
            {
                Ads = _adsService.Filter(url, minPrice, maxPrice, minMileage, maxMileage, minYear, maxYear, fuelType, gearType, bodyType, minHorse, maxHorse, Traction, Color, fromWho, Status, Swap, Region),
                FuelType = fuelType,
                GearType = gearType,
                BodyType = bodyType,
                TractionType = Traction,
                Color = Color,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                MinMileage = minMileage,
                MaxMileage = maxMileage,
                MinYear = minYear,
                MaxYear = maxYear,
                MinHorse = minMileage,
                MaxHorse = minMileage,
                FromWho = minMileage,
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
                Ads = ads,
                User = user,
                AdPicture = ads.PostingPictures ,
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

