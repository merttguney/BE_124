using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new()
        {
            new Student {Id = 1, Name = "Ali", Surname ="Yılmaz"},
            new Student {Id = 2, Name = "Cemil", Surname ="Bey"},
            new Student {Id = 3, Name = "Mahmut", Surname ="Hocca"}
        };

        public IActionResult Index()
        {

            ViewBag.Ogrenciler = students;

            return View();
        }
    }
}
