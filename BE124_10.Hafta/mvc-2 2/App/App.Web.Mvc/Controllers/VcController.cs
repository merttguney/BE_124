using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class VcController : Controller
    {
        // view component bir C# class'ı ve view'dan oluşur
        // C# class : "ViewComponents" klasöründe oluşturuyoruz
        // C# class'ının adı "ViewComponent" ile bitmeli!
        // C# kodları Invoke metodu içine yazılır
        // View() metodu ile view dosyası tetiklenir

        //View component'in view dosyası "Shared/Components/{ViewComponentAdı}/Default.cshtml" oluşturulur.

        public IActionResult Index()
        {
            return View();
        }
    }
}
