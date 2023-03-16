using Microsoft.AspNetCore.Mvc;
using SellCar.Domain.ViewModels.Ad;
using SellCar.Models;
using SellCar.Service.Intrefaces;
using System.Diagnostics;
using NLog;

namespace SellCar.Controllers
{
    public class HomeController : Controller
    {
        private IAdsService _adsService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IAdsService adsService, ILogger<HomeController> logger)
        {
            _adsService = adsService;
            _logger = logger;
           
        }
        public IActionResult Index()
        {
            _logger.LogInformation(1,"Index");
            var model = new AdsListViewModel()
            {

                Ads = _adsService.GetHomePosts()
            };
            _logger.LogInformation(2, "Index");
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
        public IActionResult Error()
        {
            var ehpf = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
            if (ehpf.Error.Source == "Microsoft.AspNetCore.Mvc.ViewFeatures" && (ehpf.Error.HResult == -2146233079 || ehpf.Error.Message.Contains("was not found")))
                return View(new ErrorViewModel(404, ehpf.Path));
            return View(new ErrorViewModel(ehpf.Path) { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/Error/{id}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] 
        public IActionResult Error(int id)
        {
            return View(new ErrorViewModel(id));
        }
    }
}