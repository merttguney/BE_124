using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("product")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("product")]
        public IActionResult Index([FromForm] ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Ürün Eklenmedi";
                return View(product);
            }

            ViewBag.SuccessMessage = "Ürün başarıyla eklendi";

            return View();
        }
    }
}
