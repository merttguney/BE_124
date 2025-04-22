using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private static readonly List<RegisterViewModel> _users = new();

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Login form opened");
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] LoginViewModel loginViewModel)
        {
            _logger.LogInformation("Login form submitted");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Login form submitted with invalid data");
                return View();
            }

            var user = _users.Find(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);

            if (user is null)
            {
                ViewBag.Error = "Username or password is wrong";
                return View();
            }

            Response.Cookies.Append("user", $"{user.Name} {user.Surname}");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("Register form opened");
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromForm] RegisterViewModel registerViewModel)
        {
            _logger.LogInformation("Register form submitted");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Register form submitted with invalid data");
                return View();
            }

            var user = _users.Find(x => x.Email == registerViewModel.Email);

            if (user is not null)
            {
                ViewBag.Error = "User with this email is already registered";

                _logger.LogWarning("Register form submitted with existing email");

                return View();
            }

            _users.Add(registerViewModel);

            _logger.LogInformation("Register succesfull");

            ViewBag.Success = "Register succesfull";

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _logger.LogInformation("Logout");

            Response.Cookies.Delete("user");

            return RedirectToAction(nameof(Login));
        }
    }
}
