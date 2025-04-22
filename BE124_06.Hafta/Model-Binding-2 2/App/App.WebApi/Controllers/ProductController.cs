using App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product {Id = 1, Name = "Product1", Price = 5},
            new Product {Id = 2, Name = "Product2", Price = 15},
            new Product {Id = 3, Name = "Product3", Price = 25},
            new Product {Id = 4, Name = "Product4", Price = 35},
            new Product {Id = 5, Name = "Product5", Price = 45},
        };

        [HttpPost("add")]
        public IActionResult Post([FromBody] Product product)
        {
            products.Add(product);
            return Ok();
        }

        [HttpGet("get1/{id}")]
        public IActionResult Get1([FromRoute] int id) 
        {
            var product = products.Find(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("get2")]
        public IActionResult Get2([FromQuery] int id) 
        {
            var product = products.Find(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("form")]
        public IActionResult Form([FromForm] Product product)
        {
            products.Add(product);
            return Ok();
        }


        // Örnek

        // Bir action içerisinde 3 adet parametre (sayı) alınacak
        // 1 parametre Route'dan
        // 1 parametre Query'dan
        // 1 parametre Header'dan

        // (Route'dan alınan değer - Query'den alınan değer) * (Header'dan alınan değer)
        // Sonuç Ok() ile geri döndürülecek
        // Postman ile denenecek














    }
}
