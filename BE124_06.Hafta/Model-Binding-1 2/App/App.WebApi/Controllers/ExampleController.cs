using App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // Örnek

        // Bir action içerisinde 3 adet parametre (sayı) alınacak
        // 1 parametre Route'dan
        // 1 parametre Query'dan
        // 1 parametre Header'dan

        // (Route'dan alınan değer - Query'den alınan değer) * (Header'dan alınan değer)
        // Sonuç Ok() ile geri döndürülecek
        // Postman ile denenecek

        [HttpGet("get/{sayi1}")]
        public IActionResult Get([FromRoute] int sayi1, [FromQuery] int sayi2, [FromHeader] int sayi3) 
        {
            var sonuc = (sayi1 - sayi2) * sayi3;
            return Ok(sonuc);
        }

        [HttpGet("get2/{sayi1}")]
        public IActionResult Get2(ExampleModel model)
        {
            var sonuc = (model.Sayi1 - model.Sayi2) * model.Sayi3;
            return Ok(sonuc);
        }


    }
}
