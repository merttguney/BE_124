﻿using App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<UserModel> Users = new();

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel user)
        {
            // Modelin durumu geçerli mi
            // Is this Model state valid?

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Users.Add(user);
            return Ok();
        }

    }
}
