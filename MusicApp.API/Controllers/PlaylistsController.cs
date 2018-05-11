using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Data;
using MusicApp.API.Helpers;

namespace MusicApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PlaylistsController : Controller
    {
        public IUsersRepository usersRepo { get; }
        public IPlaylistsRepository repo { get; }
        public PlaylistsController(IPlaylistsRepository _repo, IUsersRepository _usersRepo)
        {
            repo = _repo;
            usersRepo = _usersRepo;
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetMainPlaylist([FromQuery]int idUser)
        {
            var user = await usersRepo.Get(idUser);

            if (user == null)
                return Unauthorized();

            var playlist = await repo.GetUsersMainPlaylist(idUser);

            if (playlist == null)
                return BadRequest();
            
            return Ok(playlist.ToPlaylistDTO());
        }
    }
}