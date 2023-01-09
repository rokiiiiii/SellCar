using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellCar.DAL.Interfaces;
using SellCar.Domain.Models;
using SellCar.Domain.ViewModels.User;
using SellCar.Service.Intrefaces;

namespace SellsCar.Web.Controllers
{
    public class UserController : Controller
    {
      private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if(response.StatusCode== SellCar.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public  async Task<IActionResult> GetUser(int id)
        {
            var response = await _userService.GetUser(id);
            if (response.StatusCode == SellCar.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.StatusCode == SellCar.Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if(id==0)
            {
                return View();

            }
            var response = await _userService.GetUser(id);
            if(response.StatusCode==SellCar.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserViewModel model)
        {
            if (ModelState.IsValid) 
            {
                if(model.id==0)
                {
                    await _userService.CreateUser(model);
                }
                else
                {
                    await _userService.Edit(model.id, model);
                }
                
            }
            return RedirectToAction("GetUsers");

        }


    }
}
