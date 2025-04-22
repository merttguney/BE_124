using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
