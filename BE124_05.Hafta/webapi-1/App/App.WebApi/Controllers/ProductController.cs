using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("tufan")]
        public string Get()
        {
            return "tufan";
        }
    }
}
