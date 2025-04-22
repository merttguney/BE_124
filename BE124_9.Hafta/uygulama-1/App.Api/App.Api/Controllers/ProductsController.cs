using App.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new()
        {
            new Product {Id = 1, Name="Urun1",Description = "Aciklama1", Price = 10.99,Quantity = 5, Image="image1.png" },
            new Product {Id = 2, Name="Urun2",Description = "Aciklama2", Price = 19.99,Quantity = 15, Image="image2.png" },
            new Product {Id = 3, Name="Urun3",Description = "Aciklama3", Price = 29.99,Quantity = 25, Image="image3.png" }
        };

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_products);
        }

    }
}
