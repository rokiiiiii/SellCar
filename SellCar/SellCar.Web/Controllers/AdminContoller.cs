using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SellCar.Domain.Identity;
using SellCar.Domain.Models;
using SellCar.Domain.ViewModels.Ad;
using SellCar.Domain.ViewModels.Cars;
using SellCar.Domain.ViewModels.Regions;
using SellCar.Domain.ViewModels.Roles;
using SellCar.Domain.ViewModels.Users;
using SellCar.Service.Intrefaces;

namespace SellsCar.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IAdsService _adsService;
        private ICarService _carService;
        private IPictureService _pictureService;
        private IRegionService _regionService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AdminController(IAdsService adsService, ICarService carService, IPictureService pictureService, IRegionService regionService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _adsService = adsService;
            _carService = carService;
            _pictureService = pictureService;
            _regionService = regionService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.userCount = _userManager.Users.Count();
            ViewBag.confirmedUserCount = _userManager.Users.Where(i => i.EmailConfirmed == true).Count();
            ViewBag.adsCount = _adsService.GetPost("").Count();
            ViewBag.MostAdvertisedRegion = _regionService.MostAdvertisedRegion();
            ViewBag.LeastAnnouncedRegion = _regionService.LeastAnnouncedRegion();

            return View();
        }


        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);

                ViewBag.roles = roles;
                return View(new UserDetailViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailComfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("~/admin/user/list");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailViewModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.PhoneNumber = model.PhoneNumber;
                    user.EmailConfirmed = model.EmailComfirmed;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }
            return View(model);
        }
        public async Task<IActionResult> UserDelete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
            var Ads = _adsService.GetPost("").Where(i => i.UserId == userId).ToList();
            foreach (var ads in Ads)
            {
                _adsService.Delete(ads);
            }
            return Redirect("/admin/user/list");
        }


        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                                ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }
        public async Task<IActionResult> RoleDelete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return Redirect("/admin/role/list");
        }


        public IActionResult AdList(string url)
        {
            return View(new AdsListViewModel()
            {
                Ads = _adsService.GetPost(url)
            });
        }

        [HttpGet]
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
                HomePage = entity.HomePage,

            };
            ViewBag.Cars = _carService.GetCars();
            ViewBag.Regions = _regionService.GetRegion();
            return View(model);
        }
        [HttpPost]
        public IActionResult AdsEdit(EditAdsViewModel adsmodel, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                var ads = _adsService.GetAdDetail(adsmodel.AdsId);
                adsmodel.PostingPictures = ads.PostingPictures;
                ViewBag.Cars = _carService.GetCars();
                ViewBag.Regions = _regionService.GetRegion();
                return View(adsmodel);
            }
            var entity = _adsService.GetById(adsmodel.AdsId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Title = adsmodel.Title;
            entity.Detail = adsmodel.Detail;
            entity.RegionId = Convert.ToInt32(adsmodel.RegionId);
            entity.Brand = adsmodel.Brand;
            entity.Model = adsmodel.Model;
            entity.Year = adsmodel.year;
            entity.FuelType = adsmodel.FuelType;
            entity.GearType = adsmodel.GearType;
            entity.Mileage = adsmodel.Mileage;
            entity.BodyType = adsmodel.BodyType;
            entity.MotorPower = adsmodel.MotorPower;
            entity.EngineСapacity = adsmodel.EngineCapacity;
            entity.MaxSpeed = adsmodel.MaxSpeed;
            entity.Acceleration = adsmodel.Acceleration;
            entity.TractionType = adsmodel.TractionType;
            entity.ConsumptionСity = adsmodel.InnerCityConsumption;
            entity.OutofCityConsumption = adsmodel.OutOfCityConsumption;
            entity.Color = adsmodel.Color;
            entity.FromWho = adsmodel.FromWho;
            entity.Swap = adsmodel.Swap;
            entity.Status = adsmodel.Status;
            entity.Price = adsmodel.Price;
            entity.CarId = Convert.ToInt32(adsmodel.CarId);
            entity.HomePage = adsmodel.HomePage;
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
                            AdsId = adsmodel.AdsId,
                        };
                        _pictureService.Create(pic);

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

            return Redirect("/admin/ads/list");
        }
        public IActionResult AdsDelete(int AdsId)
        {
            var ads = _adsService.GetById(AdsId);
            if (ads != null)
            {
                _adsService.Delete(ads);
            }
            return Redirect("/admin/ads/list");
        }


        [HttpGet]
        public IActionResult CarList()
        {
            var model = new CarsListViewModel()
            { Car = _carService.GetCars() };
            return View(model);
        }
        [HttpGet]
        public IActionResult CarCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CarCreate(CarViewModel car)
        {
            var entity = new Car()
            {
                Name = car.Name,
                Url = car.Url

            };
            _carService.Create(entity);
            return Redirect("/admin/car/list");
        }
        [HttpGet]
        public IActionResult CarEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _carService.GetByIdWithPosts((int)id);
            if (entity == null)
            {
                return NotFound();
            }


            var model = new CarViewModel()
            {
                CarId = entity.CarId,
                Name = entity.Name,
                Url = entity.Url,
                Ads = entity.Ads.ToList()
            };



            return View(model);
        }
        [HttpPost]
        public IActionResult CarEdit(CarViewModel car)
        {
            var entity = _carService.GetById(car.CarId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = car.Name;
            entity.Url = car.Url;
            _carService.Update(entity);


            return Redirect("/admin/car/list");
        }
        public IActionResult CarDelete(int carId)
        {
            var entity = _carService.GetById(carId);
            if (entity != null)
            {
                _carService.Delete(entity);
            }
            return Redirect("/admin/car/list");
        }


        [HttpGet]
        public IActionResult RegionList()
        {
            var model = new RegionListViewModel()
            { Region = _regionService.GetRegion() };
            return View(model);
        }
        [HttpGet]
        public IActionResult RegionCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegionCreate(RegionViewModel region)
        {
            var entity = new Region()
            {
                Name = region.Name,

            };
            _regionService.Create(entity);
            return Redirect("/admin/region/list");
        }
        [HttpGet]
        public IActionResult RegionEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _regionService.GetByIdWithPosts((int)id);
            if (entity == null)
            {
                return NotFound();
            }

            var model = new RegionViewModel()
            {
                RegionId = entity.RegionId,
                Name = entity.Name,
                Ads = entity.Ads.ToList()
            };


            return View(model);
        }
        [HttpPost]
        public IActionResult RegionEdit(RegionViewModel region)
        {
            var entity = _regionService.GetById(region.RegionId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = region.Name;
            _regionService.Update(entity);

            return Redirect("/admin/region/list");
        }

        public IActionResult RegionDelete(int regionId)
        {
            var entity = _regionService.GetById(regionId);
            if (entity != null)
            {
                _regionService.Delete(entity);
            }
            return Redirect("/admin/region/list");
        }
    }
}
