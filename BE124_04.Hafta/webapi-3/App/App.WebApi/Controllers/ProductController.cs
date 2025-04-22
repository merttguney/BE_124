using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")] // .../api/Product
    [ApiController]
    public class ProductController : ControllerBase
    {
        // 1) 
        //[HttpGet]
        //public string Asus()
        //{
        //    return "ASUS Notebook";
        //}

        // 2)

        //[HttpGet("asus")]
        //public string Asus() // .../api/product/asus
        //{
        //    return "ASUS Notebook";
        //}

        //[HttpGet("hp")]
        //public string Hp() // .../api/product/hp
        //{
        //    return "Hp Notebook";
        //}


        // 3)

        [HttpGet("{brand}")]
        public string Laptop(string brand)
        {
            return $"{brand} Notebook"; // string interpolation
        }


    }
}
