using App.Business.DTOs;
using App.Data;
using App.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository _repo;

        //private readonly DbContext _dbContext;

        //public UserController(DbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}


        public UserController(IDataRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // DB'den kullanıcı listesini sorgula
            //var users = _dbContext.Set<UserEntity>().ToList();


            var users = await _repo.GetAll<UserEntity>();

            // Gelen entity'leri DTO'ya çevir
            var userDTOs = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name
            });

            // json olarak geri döndür

            return Ok(userDTOs);
        }


    }
}
