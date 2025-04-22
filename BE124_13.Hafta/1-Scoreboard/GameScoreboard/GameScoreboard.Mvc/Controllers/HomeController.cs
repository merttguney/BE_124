using GameScoreboard.Data.Entities;
using GameScoreboard.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameScoreboard.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger,DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var scores = await _dbContext.Set<HighScoreEntity>()
                .Include(s => s.User)
                .OrderByDescending(s => s.Score)
                .Take(10)
                .Select(s => new HighScoreViewModel
                {
                    Nickname = s.User.Nickname,
                    Score = s.Score
                })
                .ToListAsync();

            return View(scores);
        }

        [HttpGet]
        public IActionResult NewScore() 
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult NewScore() 
        //{
            
        //}


    }
}
