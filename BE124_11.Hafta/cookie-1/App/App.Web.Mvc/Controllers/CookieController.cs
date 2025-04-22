using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Set()
        {
            Response.Cookies.Append("Sinif","BE124");
            return Ok();
        }
        public IActionResult Get()
        {
            var cookie = Request.Cookies["Sinif"];

            if (cookie is null)
            {
                return NotFound();
            }

            return Ok(new {cookieValue = cookie});
        }

        public IActionResult Delete()
        {
            Response.Cookies.Delete("Sinif");

            return Ok();
        }

        public IActionResult Show()
        {
            return View();
        }

    }
}
