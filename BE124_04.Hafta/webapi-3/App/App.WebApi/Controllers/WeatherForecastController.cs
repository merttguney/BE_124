using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    // Bir C# sýnýfýnýn Controller olabilmesi için;

    // - ControllerBase sýnýfýndan inherit almasý gerekir.
    // - [ApiController] attribute'u ile nitelenmesi gerekir.
    // - Ýsminin sonu "Controller" kelimesi ile bitmesi gerekir.


    [ApiController]
    [Route("api/[controller]")] //  .../api/HavaDurumu
    //[Route("[controller]")]
    //[Route("WeatherForecast")]
    public class HavaDurumuController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
