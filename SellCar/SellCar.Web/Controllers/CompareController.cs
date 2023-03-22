
using Microsoft.AspNetCore.Mvc;
using SellCar.Domain.Extensions;
using SellCar.Domain.ViewModels.Ad;
using SellCar.Service.Intrefaces;

namespace sellcar.webui.Controllers
{
    public class compareController : Controller
    {
        private IAdsService _adsService;

        public compareController(IAdsService adsservice)
        {
            _adsService = adsservice;
        }
        public IActionResult Index()
        {
            var compare = SessionHelper.GetObjectFromJson<List<AdsViewModel>>(HttpContext.Session, "compare");
            return View(compare);
        }

        [Route("add/{id}")]
        public IActionResult Add(int id)
        {
            var entity = _adsService.GetAdDetail(id);
            if (SessionHelper.GetObjectFromJson<List<AdsViewModel>>(HttpContext.Session, "compare") == null)
            {
                List<AdsViewModel> compare = new List<AdsViewModel>();

                compare.Add(new AdsViewModel
                {
                    AdsId = entity.AdsId,
                    Brand = entity.Brand,
                    Model = entity.Model,
                    Year = entity.Year,
                    FuelType = entity.FuelType,
                    GearType = entity.GearType,
                    NumGear = entity.NumberOfGear,
                    Kilometers = entity.Mileage,
                    BodyType = entity.BodyType,
                    MumOfDoors = entity.NumberOfDoors,
                    MotorPower = entity.MotorPower,
                    EngineCapacity = entity.EngineСapacity,
                    MaxSpeed = entity.MaxSpeed,
                    Acceleration = entity.Acceleration,
                    TractionType = entity.TractionType,
                    ConsumptiOnCity = entity.ConsumptionСity,
                    ExpensesoutsideCity = entity.OutofCityConsumption,
                    AvgConsumption = entity.AverageConsumption,
                    FuelTankVolume = entity.FuelTankVolume,
                    Color = entity.Color,
                    Price = entity.Price,
                    CarId = entity.CarId,
                    PicUrl = entity.PostingPictures[0].Url,
                    Name = entity.Car.Name

                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            }
            else
            {
                List<AdsViewModel> compare = SessionHelper.GetObjectFromJson<List<AdsViewModel>>(HttpContext.Session, "compare");
                compare.Add(new AdsViewModel
                {
                    AdsId = entity.AdsId,
                    Brand = entity.Brand,
                    Model = entity.Model,
                    Year = entity.Year,
                    FuelType = entity.FuelType,
                    GearType = entity.GearType,
                    NumGear = entity.NumberOfGear,
                    Kilometers = entity.Mileage,
                    BodyType = entity.BodyType,
                    MumOfDoors = entity.NumberOfDoors,
                    MotorPower = entity.MotorPower,
                    EngineCapacity = entity.EngineСapacity,
                    MaxSpeed = entity.MaxSpeed,
                    Acceleration = entity.Acceleration,
                    TractionType = entity.TractionType,
                    ConsumptiOnCity = entity.ConsumptionСity,
                    ExpensesoutsideCity = entity.OutofCityConsumption,
                    AvgConsumption = entity.AverageConsumption,
                    FuelTankVolume = entity.FuelTankVolume,
                    Color = entity.Color,
                    Price = entity.Price,
                    CarId = entity.CarId
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<AdsViewModel> compare = SessionHelper.GetObjectFromJson<List<AdsViewModel>>(HttpContext.Session, "compare");
            int index = isExist(id);
            compare.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "compare", compare);
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<AdsViewModel> compare = SessionHelper.GetObjectFromJson<List<AdsViewModel>>(HttpContext.Session, "compare");
            for (int i = 0; i < compare.Count; i++)
            {
                if (compare[i].AdsId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}