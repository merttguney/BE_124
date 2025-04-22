using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new()
        {
            new Product {Id = 1 , Name = "laptop" , Description = "Açıklama1", Price = 999.90, Quantity = 10, Image = "img1.png"},
            new Product {Id = 2 , Name = "monitor" , Description = "Açıklama2", Price = 699.90, Quantity = 5, Image = "img2.png"},
            new Product {Id = 3 , Name = "mouse" , Description = "Açıklama3", Price = 99.90, Quantity = 102, Image = "img3.png"},
            new Product {Id = 4 , Name = "keyboard" , Description = "Açıklama4", Price = 199.90, Quantity = 10, Image = "img4.png"},
            new Product {Id = 5 , Name = "speaker" , Description = "Açıklama5", Price = 299.90, Quantity = 50, Image = "img5.png"}
        };

        public IActionResult List()
        {
            ViewBag.Urunler = products;

            return View();
        }
    }
}
