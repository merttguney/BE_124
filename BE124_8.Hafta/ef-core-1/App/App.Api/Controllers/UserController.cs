﻿using App.Api.Data;
using App.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private static readonly List<UserModel> Users = new();

        private AppDbContext Context { get; }

        public UserController()
        {
            Context = new AppDbContext();
            Context.Database.EnsureCreated();
        }


        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(Users);
            // --------------------------------------

            var users = Context.Users.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var user = Users.Find(x => x.Id == id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            //return Ok(user);
            // -----------------------------------

            var user = Context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [HttpPost]
        public IActionResult Create([FromBody] UserModel user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //user.Id = Users.Count + 1;
            //Users.Add(user);

            //return Ok(user);
            // ---------------------------

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.Id = 0; // default değer

            Context.Users.Add(user); // INSERT INTO işlemine karşılık gelir

            // gerçekten veritabanın eklenmesi için SaveChanges() metodunun çalıştırılması gerekiyor.
            // aksi takdirde eklenen veri önbellekte kalıyor
            Context.SaveChanges();

            return Ok(user);

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UserModel user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var userIndex = Users.FindIndex(x => x.Id == id);

            //if (userIndex < 0)
            //{
            //    return NotFound();
            //}

            //user.Id = id;
            //Users[userIndex] = user;

            //return Ok(user);
            // ---------------------------------


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbUser = Context.Users.FirstOrDefault(x => x.Id == id);

            if (dbUser is null)
            {
                return NotFound();
            }

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            dbUser.Password = user.Password;

            Context.SaveChanges();

            return Ok(user);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var userIndex = Users.FindIndex(x => x.Id == id);

            //if (userIndex < 0)
            //{
            //    return NotFound();
            //}

            //Users.RemoveAt(userIndex);

            //return Ok();
            // -----------------------------

            var dbUser = Context.Users.FirstOrDefault(x => x.Id == id);

            if (dbUser is null)
            {
                return NotFound();
            }

            Context.Users.Remove(dbUser);
            Context.SaveChanges();

            return Ok();
        }



    }
}
