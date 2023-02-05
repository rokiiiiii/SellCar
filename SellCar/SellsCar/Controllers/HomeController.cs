using Microsoft.AspNetCore.Mvc;
using SellCar.Domain.ViewModels.Ad;
using SellCar.Models;
using SellCar.Service.Intrefaces;
using System.Diagnostics;

namespace SellCar.Controllers
{
    public class HomeController : Controller
    {
        private IAdsService _adsService;
        public HomeController(IAdsService adsService)
        {
            _adsService = adsService;
        }
        public IActionResult Index()
        {
            var model = new AdsListViewModel()
            {
                Ads = _adsService.GetHomePosts()
            };
            return View(model);
        }
        public IActionResult Search(string q)
        {
            var model = new AdsListViewModel()
            {
                Ads = _adsService.GetSearchResult(q)
            };
            return View(model);
        }
    }
}