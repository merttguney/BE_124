using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<string> productNames = new()
            {
                "Elma", "Armut","Vişne"
            };

            return View(productNames);
        }
    }
}
