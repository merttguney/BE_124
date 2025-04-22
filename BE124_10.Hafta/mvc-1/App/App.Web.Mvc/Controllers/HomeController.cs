using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<ProductViewModel> products = new()
        {
            new ProductViewModel {Id = 1, Name = "urun1", Price= 10.90},
            new ProductViewModel {Id = 2, Name = "urun2", Price= 20.90},
            new ProductViewModel {Id = 3, Name = "urun3", Price= 30.90}
        };

        public IActionResult Index()
        {
            return View();
        }

        [Route("viewmodel-ile-products")]
        public IActionResult WithViewModel()
        {
            return View(products);
        }

        [Route("viewbag-ile-products")]
        public IActionResult WithViewBag()
        {
            ViewBag.Products = products;
            return View();
        }

        public void DictionaryUsage()
        {
            //Dictionary<string, int> data = new()
            //{
            //    { "Ali", 90 },
            //    { "Veli" , 50},
            //    { "Mahmut",45 }
            //};


            Dictionary<string, int> data = new();

            data.Add("Ali",90);
            data.Add("Veli",50);
            data.Add("Mahmut",45);

            data["tufan"] = 30;

            // eleman silme
            data.Remove("Mahmut");

            // varmý kontrolü
            //var IsExist = data.ContainsKey("Ali");
            var IsExist = data.Keys.Contains("Ali");

            // yoksa ekle, varsa ekleme
            var IsAdded = data.TryAdd("Ali",80);

            // Dictionary içindeki bir yapýyý okumak
            int point = data["Ali"];



        }

        [Route("viewdata-ile-products")]
        public IActionResult WithViewData()
        {
            // 1. yöntem
            //ViewData.Add("Products",products);

            // 2. yöntem
            ViewData["Products"] = products;

            return View();
        }

        [Route("viewdata-ile-redirect")]
        public IActionResult RedirectWithViewData()
        {
            ViewData["Products"] = products;

            return RedirectToAction(nameof(RedirectWithViewDataTarget));
        }

        [Route("viewdata-ile-redirect-target")]
        public IActionResult RedirectWithViewDataTarget()
        {
            return View("~/Views/Home/WithViewData.cshtml");
        }


        [Route("tempdata-ile-products")]
        public IActionResult WithTempData()
        {
            TempData["Products"] = products;

            return View();
        }

        [Route("tempdata-ile-redirect")]
        public IActionResult RedirectWithTempData()
        {
            TempData["Products"] = "Siliconmade Academy";

            return RedirectToAction(nameof(RedirectWithTempDataTarget));
        }

        [Route("tempdata-ile-redirect-target")]
        public IActionResult RedirectWithTempDataTarget()
        {
            return View("~/Views/Home/WithTempData.cshtml");
        }



    }
}
