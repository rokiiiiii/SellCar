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
        public IActionResult List(string url, string min_price, string max_price, string min_kilometers, string max_kilometers, string min_year, string max_year, string[] fuel_type, string[] gear_type, string[] body_type, string min_horse, string max_horse, string[] traction, string[] color, string from_who, string status, string swap, string[] region)
        {
            var model = new AdsListViewModel()
            {
                Ads = _adsService.Filter(url, min_price, max_price, min_kilometers, max_kilometers, min_year, max_year, fuel_type, gear_type, body_type, min_horse, max_horse, traction, color, from_who, status, swap, region),
                fuel_type = fuel_type,
                gear_type = gear_type,
                body_type = body_type,
                traction = traction,
                color = color,
                min_price = min_price,
                max_price = max_price,
                min_kilometers = min_kilometers,
                max_kilometers = max_kilometers,
                min_year = min_year,
                max_year = max_year,
                min_horse = min_kilometers,
                max_horse = min_kilometers,
                from_who = min_kilometers,
                status = status,
                swap = swap,
                region = region,
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

