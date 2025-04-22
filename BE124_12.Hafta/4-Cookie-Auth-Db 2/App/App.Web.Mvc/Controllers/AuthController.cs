using App.Web.Mvc.Data;
using App.Web.Mvc.Data.Entities;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace App.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AppDbContext _dbContext;

        //const string UserMail = "admin@admin.com";
        //const string UserPassword = "1234";

        public AuthController(ILogger<AuthController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Invalid login attempt";
                return View();
            }

            //if (loginViewModel.Email != UserMail || loginViewModel.Password != UserPassword)
            //{
            //    ViewBag.Error = "User not found";
            //    return View(loginViewModel);
            //}


            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == loginViewModel.Email);

            if (user is null || user.Password != loginViewModel.Password)
            {
                ViewBag.Error = "User not found";
                return View();
            }

            // Login işlemleri

            await DoLoginOperations(user);


            return RedirectToAction("Index", "Home");
        }

        private Task DoLoginOperations(UserEntity user)
        {
            // claim listesi
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Email ,loginViewModel.Email),
            //    new Claim(ClaimTypes.Role, "Admin")
            //};



            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Email ,user.Email),
            //    new Claim(ClaimTypes.Role, "Admin"),
            //    new Claim(ClaimTypes.Name, "Siliconmade"),
            //    new Claim("server-time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            //};

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email ,user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim("server-time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            // claim listesinden oluşan kimlik
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // authentication işlemi için ayarlar eklenebilir.
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10), // geçerlilik süresi
                IsPersistent = true // beni hatırla işlemleri için kullanılır
            };


            return HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }
    }
}
