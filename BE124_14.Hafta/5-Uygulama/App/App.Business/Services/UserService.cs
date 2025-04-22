using App.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services
{
    public class UserService
    {
        private readonly IHttpClientFactory _clientFactory;

        private HttpClient Client => _clientFactory.CreateClient("data-api");

        //private readonly DbContext _dbContext;

        //public UserService(/*DbContext dbContext*/)
        //{
        //    //_dbContext = dbContext;
        //}

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            // DB'den userEntity'leri çek
            // UserDTO'ya dönüştür

            //return await _dbContext.Set<UserEntity>()
            //    .Select(x => new UserDTO
            //    {
            //        Id = x.Id,
            //        Name = x.Name
            //    }).ToListAsync();


            // --------------------------------------

            //var httpClient = new HttpClient();

            var response = await Client.GetAsync("/api/user");

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }

            var responseObjects = await response.Content.ReadFromJsonAsync<List<UserDTO>>();

            return responseObjects;

        }

    }
}
