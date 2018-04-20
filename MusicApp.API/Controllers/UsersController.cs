using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.ApplicationLogic;
using MusicApp.API.DTOs;

namespace MusicApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly UsersRepository repo;

        public UsersController(UsersRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetUsers()
        // {
        //     var users = await repo.GetAll();
        //     var usersToReturn = mapper.Map<IEnumerable<UserDetailDTO>>(users);
        //     return Ok(users);
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await repo.Get(id);
            var userDetail = mapper.Map<UserDetailDTO>(user);
            return Ok(userDetail);
        }
    }
}