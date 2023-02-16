using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SellCar.Domain.Identity;
using SellCar.Domain.Models;
using SellCar.Domain.ViewModels.Ad;
using SellCar.Domain.ViewModels.Favorites;
using SellCar.Domain.ViewModels.Profile;
using SellCar.Service.Intrefaces;
using static SellCar.Domain.ViewModels.Favorites.FavoriteViewModel;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace SellsCar.Web.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "User")]
    public class UserController : Controller
    {
        Random rnd;
        private IAdsService _adsService;
        private IPictureService _picService;
        private ICarService _carService;
        private IFavoriteService _FavoriteService;
        private IRegionService _regionService;
        private UserManager<User> _user;

        public UserController(IAdsService adsService, IPictureService picService, ICarService carService, IFavoriteService favoriteService, IRegionService regionService, UserManager<User> user)
        {
            rnd = new Random();
            _adsService = adsService;
            _picService = picService;
            _carService = carService;
            _FavoriteService = favoriteService;
            _regionService = regionService;
            _user = user;
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _user.GetUserAsync(User);
            var ads = _adsService.GetPost("").Where(i => i.UserId == Convert.ToString(user.Id)).ToList();
            var favs = _FavoriteService.GetFavByUserId(_user.GetUserId(User));
            ViewBag.favs = favs.Count();
            ViewBag.NumOfAds = ads.Count();
            var model = new UserProfileViewModel()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                MembershipDate = user.MembershipDate.ToString().TrimEnd('0', ':'),
            };
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> UserProfileEdit(UserProfileViewModel model)
        {
            var user = await _user.GetUserAsync(User);

            var ads = _adsService.GetPost("").Where(i => i.UserId == Convert.ToString(user.Id)).ToList();
            var favs = _FavoriteService.GetFavByUserId(_user.GetUserId(User));

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _user.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Redirect("/user/profile");
                }
            }
            return RedirectToAction("Profile", model);
        }


        public IActionResult CreateAds()
        {
            ViewBag.Car = _carService.GetCars();
            ViewBag.Region = _regionService.GetRegion();
            return View(new CreateAdsViewModel());
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CreateAds(CreateAdsViewModel Ads, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Car = _carService.GetCars();
                ViewBag.Region = _regionService.GetRegion();
                return View(Ads);
            }
            int randomnum = rnd.Next(100000000, 999999999);
            var entity = new Ads
            {
                AdsId = randomnum,
                Title = Ads.Title,
                Detail = Ads.Detail,
                RegionId = Convert.ToInt32(Ads.RegionId),
                Brand = Ads.Brand,
                Model = Ads.Model,
                Year = Ads.year,
                FuelType = Ads.FuelType,
                GearType = Ads.GearType,
                Mileage = Ads.Mileage,
                BodyType = Ads.BodyType,
                MotorPower = Ads.MotorPower,
                EngineСapacity = Ads.EngineCapacity,
                MaxSpeed = Ads.MaxSpeed,
                Acceleration = Ads.Acceleration,
                TractionType = Ads.TractionType,
                ConsumptionСity = Ads.InnerCityConsumption,
                OutofCityConsumption = Ads.OutOfCityConsumption,
                Color = Ads.Color,
                FromWho = Ads.FromWho,
                Swap = Ads.Swap,
                Status = Ads.Status,
                Price = Ads.Price,
                DateCreate = DateTime.Now,
                CarId = Convert.ToInt32(Ads.CarId),
                UserId = _user.GetUserId(User)
            };
            _adsService.Create(entity);
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {

                        var fileName = Path.GetFileName(file.FileName);
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        var picture = new Picture()
                        {
                            Url = newFileName,
                            AdsId = randomnum,
                        };
                        _picService.Create(picture);

                        var filepath =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img")).Root + $@"\{newFileName}";
                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }
            TempData["message"] = $"The tool with the title {entity.Title} and the ad number {entity.AdsId} is online.";
            return Redirect("/cars");
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult AdsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _adsService.GetAdDetail((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new EditAdsViewModel()
            {
                AdsId = entity.AdsId,
                Title = entity.Title,
                Detail = entity.Detail,
                RegionId = Convert.ToString(entity.RegionId),
                Brand = entity.Brand,
                Model = entity.Model,
                year = entity.Year,
                FuelType = entity.FuelType,
                GearType = entity.GearType,
                Mileage = entity.Mileage,
                BodyType = entity.BodyType,
                MotorPower = entity.MotorPower,
                EngineCapacity = entity.EngineСapacity,
                MaxSpeed = entity.MaxSpeed,
                Acceleration = entity.Acceleration,
                TractionType = entity.TractionType,
                InnerCityConsumption = entity.ConsumptionСity,
                OutOfCityConsumption = entity.OutofCityConsumption,
                Color = entity.Color,
                FromWho = entity.FromWho,
                Swap = entity.Swap,
                Status = entity.Status,
                Price = entity.Price,
                CarId = Convert.ToString(entity.CarId),
                PostingPictures = entity.PostingPictures,

            };
            ViewBag.Car = _carService.GetCars();
            ViewBag.Region = _regionService.GetRegion();
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult AdsEdit(EditAdsViewModel AdsModel, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                var ads = _adsService.GetAdDetail(AdsModel.AdsId);
                AdsModel.PostingPictures = ads.PostingPictures;
                ViewBag.Car = _carService.GetCars();
                ViewBag.Region = _regionService.GetRegion();

                return View(AdsModel);
            }
            var entity = _adsService.GetById(AdsModel.AdsId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = AdsModel.Title;
            entity.Detail = AdsModel.Detail;
            entity.RegionId = Convert.ToInt32(AdsModel.RegionId);
            entity.Brand = AdsModel.Brand;
            entity.Model = AdsModel.Model;
            entity.Year = AdsModel.year;
            entity.FuelType = AdsModel.FuelType;
            entity.GearType = AdsModel.GearType;
            entity.Mileage = AdsModel.Mileage;
            entity.BodyType = AdsModel.BodyType;
            entity.MotorPower = AdsModel.MotorPower;
            entity.EngineСapacity = AdsModel.EngineCapacity;
            entity.MaxSpeed = AdsModel.MaxSpeed;
            entity.Acceleration = AdsModel.Acceleration;
            entity.TractionType = AdsModel.TractionType;
            entity.ConsumptionСity = AdsModel.InnerCityConsumption;
            entity.OutofCityConsumption = AdsModel.OutOfCityConsumption;
            entity.Color = AdsModel.Color;
            entity.FromWho = AdsModel.FromWho;
            entity.Swap = AdsModel.Swap;
            entity.Status = AdsModel.Status;
            entity.Price = AdsModel.Price;
            entity.CarId = Convert.ToInt32(AdsModel.CarId);
            _adsService.Update(entity);

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {

                        var fileName = Path.GetFileName(file.FileName);
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        var pic = new Picture()
                        {
                            Url = newFileName,
                            AdsId = AdsModel.AdsId,
                        };
                        _picService.Create(pic);

                        var filepath =
                        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img")).Root + $@"\{newFileName}";
                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }
            TempData["message"] = $"The tool with the title {entity.Title} and the ad number {entity.AdsId} is online.";
            TempData["alert-type"] = "alert-warning";
            return Redirect("/user/ad");
        }
        public IActionResult AdsDelete(int? id)
        {
            var entity = _adsService.GetById((int)id);
            if (entity != null)
            {
                _adsService.Delete(entity);
            }
            TempData["message"] = $"The tool {entity.AdsId} with the title {entity.Title} has been taken down.";
            TempData["alert-type"] = "alert-danger";
            return Redirect("/user/ad");
        }
        public IActionResult AdsPicDelete(string id)
        {
            var Pic = _picService.GetByUrl(id);
            if (Pic != null)
            {
                _picService.Delete(Pic);
            }
            TempData["message"] = "Picture deleted";
            return Redirect("/user/Ads/" + Pic.Ads);

        }
        public IActionResult FavoriteAds()
        {
            var favoriilanlar = _FavoriteService.GetFavByUserId(_user.GetUserId(User));
            var model = new FavoriteViewModel()
            {
                Favs = favoriilanlar.Select(i => new FavItemModel()
                {
                    AdsId = i.AdsId,
                    PicUrl = i.Ads.PostingPictures[0].Url,
                    Title = i.Ads.Title,
                    Name = i.Ads.Car.Name,
                    Brand = i.Ads.Brand,
                    Model = i.Ads.Model,
                    Price = i.Ads.Price
                }).ToList()
            };
            return View(model);
        }
        public IActionResult CreateFavAds(int? id)
        {
            var userId = _user.GetUserId(User);
            _FavoriteService.Create(new Favorite()
            {
                AdsId = (int)id,
                UserId = userId,
            });
            TempData["message"] = "The ad has been added to favourites.";
            TempData["alert-type"] = "alert-success";
            return Redirect("/user/favorites");
        }
        public IActionResult DeleteFavAds(int? id)
        {
            var entity = _FavoriteService.GetFavByUserId(_user.GetUserId(User)).Where(i => i.AdsId == id).FirstOrDefault();
            if (entity != null)
            {
                _FavoriteService.Delete(entity);
            }
            TempData["message"] = $"The tool titled {entity.Ads.Title} has been removed from the favourite.";

            TempData["alert-type"] = "alert-danger";
            return Redirect("/user/favorites");
        }
        public IActionResult Stats()
        {
            var userId = _user.GetUserId(User);
            var ads = _adsService.GetPost("").Where(i => i.UserId == userId).ToList();
            var favs = _FavoriteService.GetFavByUserId(userId);
            ViewBag.favs = favs.Count();
            ViewBag.NumAds = ads.Count();
            return View();
        }
        public IActionResult Ads()
        {
            var userId = _user.GetUserId(User);
            var ads = _adsService.GetPost("").Where(i => i.UserId == userId).ToList();
            var model = new AdsListViewModel()
            {
                Ads = ads,
            };
            return View(model);
        }
    }
}
