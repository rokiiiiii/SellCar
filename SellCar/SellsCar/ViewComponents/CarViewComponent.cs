using Microsoft.AspNetCore.Mvc;
using SellCar.Service.Intrefaces;

namespace SellsCar.Web.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private ICarService _carService;

        public CarViewComponent(ICarService carService)
        {
            _carService = carService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_carService.GetCars());
        }
    }
}
