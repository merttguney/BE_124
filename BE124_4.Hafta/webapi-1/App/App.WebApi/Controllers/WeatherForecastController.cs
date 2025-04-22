using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    // --------- C#'ta ATTRIBUTE KULLANIMI -----------

    // Attribute'lar alt�ndaki attribute olmayan ilk yap�ya bir tak�m �zellikler kazand�r�r.

    [ApiController] // WeatherForecastController '�n bir api controller'� olmas�n� sa�l�yor.
    [Route("[controller]")] // alt�ndaki controller'�n route'unu belirlemek i�in kullan�l�r.
    public class WeatherForecastController : ControllerBase
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
