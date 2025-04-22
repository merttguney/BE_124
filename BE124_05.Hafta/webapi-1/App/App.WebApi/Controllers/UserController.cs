using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")] // ..../api/user
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("name")]
        public string UserName() // ..... /api/user/name
        {
            return "Murat Yılmaz";
        }

        [HttpGet("namebold")]
        public string UserNameBold()
        {
            return "<b>Murat Yılmaz</b>";
        }


        // IActionResult -> interface
        [HttpGet("namebold2")]
        public IActionResult UserNameBold2()
        {
            return Content("<b>Murat Yılmaz</b>", "text/html;charset=utf-8");
        }

        [HttpGet("namebold3")]
        public IActionResult UserNameBold3()
        {
            // Anonim obje (bir class'tan türetilmemiş objeler)
            var result = new
            {
                name = "Ali",
                surname = "Yılmaz"
            };

            return Ok(result);

        }

        [HttpGet("namebold4")]
        public IActionResult UserNameBold4()
        {
            //return RedirectToAction("UserNameBold");
            //return RedirectToAction("UserNameBold", "Product");

            return RedirectToAction(nameof(UserNameBold));

        }


        [HttpGet("yonlendir")]
        public IActionResult Yonlendir()
        {
            return LocalRedirect("/api/product/tufan");
        }
        [HttpGet("yonlendir2")]
        public IActionResult Yonlendir2()
        {
            return RedirectToAction("Get","Product");
        }

        [HttpGet("google")]
        public IActionResult Yonlendir3()
        {
            return Redirect("https://www.google.com");
        }





        // Aşağıdaki endpointleri içeren WebApi uygulamasını yazın

        // 1) https://www.siliconmadeacademy.com  adresine yönlendirme yapan bir endpoint oluşturun 
        // 2) 1. action'a yönlendirme yapan bir endpoint oluşturun 
        // 3) Bir product nesnesini 200 status kodu ile döndüren bir endpoint oluşturun 
        // 4) İsminizi italik olarak yazdıran bir endpoint oluşturun 






    }
}
