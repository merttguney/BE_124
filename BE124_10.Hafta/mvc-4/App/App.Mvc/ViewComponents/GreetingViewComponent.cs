using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Mvc.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            //return View("~/Home/index.cshtml");
            return View(new GreetingViewModel { Name = name });
            
        }
    }
}
