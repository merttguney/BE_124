﻿using GameScoreboard.Data.Entities;
using GameScoreboard.Mvc.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameScoreboard.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly IConfiguration _config;

        public AuthController(DbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
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
                return View();
            }

            var dbSet = _dbContext.Set<UserEntity>();
            var user = dbSet.FirstOrDefault(u => u.Nickname == loginViewModel.Nickname && u.Password == loginViewModel.Password);

            if (user is null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, user.Nickname),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            //};

            //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //var principal = new ClaimsPrincipal(identity);

            //var authProperties = new AuthenticationProperties
            //{
            //    IsPersistent = true
            //};

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);


            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, user.Nickname),
                new Claim(JwtClaimTypes.Subject, user.Id.ToString())
            };

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));

            var tokenOptions = new JwtSecurityToken(
                issuer:"GameScoreboard",
                audience:"MVC",
                claims: claims,
                expires:DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256)
                );
            
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            Response.Cookies.Append("access_token", tokenString, new CookieOptions
            {
                HttpOnly = true, // js ile erişilmesin
                Secure = true, // https kullanabilsin
                SameSite = SameSiteMode.Strict // sadece bu sitede kullanılabilsin
            });


            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

    }
}
