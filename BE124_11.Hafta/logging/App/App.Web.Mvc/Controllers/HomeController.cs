using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("Ana sayfaya istekte bulunuldu.");


            //_logger.LogInformation("{tarih} - Ana sayfaya istekte bulunuldu.", DateTime.Now);


            //_logger.LogInformation("{tarih} - Ana sayfaya istekte bulunuldu.", DateTime.Now);


            _logger.LogError("{tarih} - Ana sayfaya istekte bulunuldu.", DateTime.Now);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
