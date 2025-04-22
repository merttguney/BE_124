using App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputsController : ControllerBase
    {
        // Aşağıdaki endpointleri içeren WebApi uygulamasını yazın

        // 1) https://www.siliconmadeacademy.com  adresine yönlendirme yapan bir endpoint oluşturun 
        // 2) 1. action'a yönlendirme yapan bir endpoint oluşturun 
        // 3) Bir product nesnesini 200 status kodu ile döndüren bir endpoint oluşturun 
        // 4) İsminizi italik olarak yazdıran bir endpoint oluşturun 

        [HttpGet("siliconmade")]
        public IActionResult SiliconmadeRedirect()
        {
            return Redirect("https://www.siliconmadeacademy.com");
        }

        [HttpGet("siliconmade-yonlendir")]
        public IActionResult SiliconmadeRedirectToAction()
        {
            //return RedirectToAction("SiliconmadeRedirect");
            return RedirectToAction(nameof(SiliconmadeRedirect));
        }

        [HttpGet("product")]
        public IActionResult Product()
        {
            var product = new Product
            {
                Name = "Kalem",
                Price = 10
            };

            return Ok(product);
        }

        [HttpGet("italic")]
        public IActionResult ItalicName()
        {
            return Content("<i>Cemil</i>", "text/html;charset=utf-8");
        }
    }
}
