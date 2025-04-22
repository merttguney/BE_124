using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
