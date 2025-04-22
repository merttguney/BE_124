using App.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // -------------------------------
        //public IActionResult AboutUs()
        //{
        //    return View();
        ////}
        //
        // -------------------------------

        //[Route("hakkimizda")]
        //public IActionResult AboutUs()
        //{
        //    return View();
        //}

        // -------------------------------

        //[Route("hakkimizda/{id:int}")]
        //public IActionResult AboutUs([FromRoute] int id)
        //{
        //    ViewBag.Id = id;
        //    return View();
        //}

        // -------------------------------

        [Route("hakkimizda/{id:int}/{title}")]
        public IActionResult AboutUs([FromRoute] int id, [FromRoute] string title)
        {
            ViewBag.Id = id;
            ViewBag.Title = title;  
            return View();
        }
    }
}
