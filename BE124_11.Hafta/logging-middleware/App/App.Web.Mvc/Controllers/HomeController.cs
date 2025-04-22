using App.Web.Mvc.Models;
using App.Web.Mvc.Models.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IOptions<UserConfigModel> _userConfig;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<UserConfigModel> userConfig)
        {
            _logger = logger;
            _configuration = configuration;
            _userConfig = userConfig;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("Ana sayfaya istekte bulunuldu.");


            //_logger.LogInformation("{tarih} - Ana sayfaya istekte bulunuldu.", DateTime.Now);


            //_logger.LogInformation("{tarih} - Ana sayfaya istekte bulunuldu.", DateTime.Now);


            //_logger.LogError("{tarih} - Ana sayfaya istekte bulunuldu.", DateTime.Now);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("home/config/{key}")]
        public IActionResult ConfigValue([FromRoute] string key)
        {
            var v = _configuration.GetValue<string>(key);
            //var v = _configuration.GetValue<int>(key);

            return Ok( new { value = v } );
        }

        [HttpGet("home/user")]
        public IActionResult CustomUser()
        {
            return Ok(_userConfig.Value);
        }
    }
}
