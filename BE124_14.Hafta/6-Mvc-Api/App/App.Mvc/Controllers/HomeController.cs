using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://localhost:7215/api/product");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            var products = await response.Content.ReadFromJsonAsync<Product[]>();

            return View(products);
        }

    }
}
