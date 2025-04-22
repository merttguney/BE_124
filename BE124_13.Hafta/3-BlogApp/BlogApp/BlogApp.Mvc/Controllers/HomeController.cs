using BlogApp.Data.Entities;
using BlogApp.Mvc.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace BlogApp.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var blogs = await _dbContext.Set<BlogPostEntity>()
                .Where(u => u.UserId == userId)
                .Include(s => s.User)
                .OrderByDescending(s => s.CreatedAt)
                .Take(10)
                .Select(s => new BlogTableViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Size = s.Content.Length,
                    CreatedAt = s.CreatedAt
                })
                .ToListAsync();

            return View(blogs);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog([FromForm] NewBlogViewModel newBlogViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = GetUserId();

            var blogPost = new BlogPostEntity
            {
                Title =newBlogViewModel.Title,
                Content = newBlogViewModel.Content,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

           _dbContext.Add(blogPost);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Detail([FromRoute] long id)
        {
            var userId = GetUserId();


            var blog = await _dbContext.Set<BlogPostEntity>()
                .Include(s => s.User)
                .SingleOrDefaultAsync(s => s.UserId == userId && s.Id == id);

            // Normalde view'a veri gönderirken doðrudan Entity göndermek istemeyiz. Fakat entity gönderirsek de çalýþýr

            return View(blog);
        }

        public long GetUserId()
        {
            return long.Parse(User.FindFirstValue(JwtClaimTypes.Subject) ?? throw new InvalidOperationException());
        }

    }
}
