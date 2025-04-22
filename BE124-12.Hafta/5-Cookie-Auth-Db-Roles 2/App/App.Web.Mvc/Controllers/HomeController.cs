using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Moderator")]
        public IActionResult Moderator()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")] // Admin veya Moderator. ", " -> veya anlamýna geliyor
        public IActionResult AdminOrModerator()
        {
            return View();
        }

        // ikis role de sahip olmasý gerekiyorsa attribute'lar aþaðýdaki gibi verilir
        // bu uygulamada db yapýsý buna uygun deðil.
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        public IActionResult AdminAndModerator()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
