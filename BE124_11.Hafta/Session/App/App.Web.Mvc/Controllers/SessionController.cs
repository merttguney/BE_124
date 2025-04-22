using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Set()
        {
            HttpContext.Session.SetString("Username","Cemil");
            HttpContext.Session.SetInt32("Age", 56);
            return Ok();
        }
        public IActionResult Get()
        {
            var userName = HttpContext.Session.GetString("Username");
            var age = HttpContext.Session.GetInt32("Age");
            return Ok(new {username = userName , age = age});
        }
        public IActionResult Delete()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Age");
            return Ok();
        }
        public IActionResult Show()
        {
            return View();
        }
    }
}
