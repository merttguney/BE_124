using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            List<Product>? products = await GetProductFromApi();
            ViewData["Products"] = products;
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

        private async Task<List<Product>>? GetProductFromApi()
        {
            string url = "https://localhost:7092/api/products"; // api uygulamas�n�n url'si

            HttpClient client = new HttpClient(); // Http istekleri yapmam�z� sa�lar (JS -> Fetch)

            HttpResponseMessage response = await client.GetAsync(url); // Get iste�i yap�l�r

            if (response.IsSuccessStatusCode)
            {
                List<Product>? products = await response.Content.ReadFromJsonAsync<List<Product>>(); // deserialize

                return products;
            }
            else
            {
                return null;
            }
        }



    }
}
