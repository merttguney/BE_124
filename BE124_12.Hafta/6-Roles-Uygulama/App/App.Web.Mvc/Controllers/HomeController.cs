using App.Web.Mvc.Data;
using App.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace App.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Moderator")]
        public IActionResult Moderator()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")] // Admin veya Moderator. ", " -> veya anlamýna geliyor
        public IActionResult AdminOrModerator()
        {
            return View();
        }

        // ikis role de sahip olmasý gerekiyorsa attribute'lar aþaðýdaki gibi verilir
        // bu uygulamada db yapýsý buna uygun deðil.
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        public IActionResult AdminAndModerator()
        {
            return View();
        }

        public async Task<IActionResult> UnapprovedUsers()
        {
            var users = await _dbContext.Users
                .Where(u => !u.IsApproved)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                }).ToListAsync();

            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveUser(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id /* && !u.IsApproved*/ );

            if (user is null)
            {
                return NotFound();
            }

            user.IsApproved = true;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(UnapprovedUsers));
        }





        public IActionResult Privacy()
        {
            return View();
        }

    }
}
