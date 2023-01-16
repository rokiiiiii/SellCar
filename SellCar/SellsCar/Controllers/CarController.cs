using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellCar.Domain.Extensions;
using SellCar.Domain.ViewModels.Car;
using SellCar.Service.Intrefaces;

namespace SellsCar.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        public IActionResult GetCars()
        {
            var response = _carService.GetCars();
            if (response.StatusCode == SellCar.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if (response.StatusCode == SellCar.Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }
            return View("Error", $"{response.Description}");
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _carService.GetCar(id);
            if (response.StatusCode == SellCar.Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel model)
        {

            ModelState.Remove("Id");
            ModelState.Remove("YearCreate");
            if (ModelState.IsValid)
            {

                await _carService.Edit(model.Id, model);

                return RedirectToAction("GetCars");
            }
            var errorMessage = ModelState.Values
                .SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList().Join();
            return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage });
        }


        [HttpGet]
        public async Task<ActionResult> GetCar(int id, bool isJson)
        {
            var response = await _carService.GetCar(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> GetCar(string term)
        {
            var response = await _carService.GetCar(term);
            return Json(response.Data);
        }

        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _carService.GetTypes();
            return Json(types.Data);
        }
    }
}

