using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class SectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            List<string> userNames = new()
            {
                "Ali",
                "Veli",
                "Aslı",
                "Ayşe",
                "Mehmet"
            };

            ViewData["users"] = userNames;

            return View();
        }
    }
}
