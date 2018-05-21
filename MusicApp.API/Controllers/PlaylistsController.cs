using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Data;
using MusicApp.API.DTOs;
using MusicApp.API.Helpers;

namespace MusicApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PlaylistsController : Controller
    {
        private readonly ISongRepository songsRepo;
        private readonly IUsersRepository usersRepo;
        public IPlaylistsRepository repo { get; }

        public PlaylistsController(IPlaylistsRepository _repo,
                                   IUsersRepository _usersRepo,
                                   ISongRepository _songsRepo)
        {
            repo = _repo;
            usersRepo = _usersRepo;
            songsRepo = _songsRepo;
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetMainPlaylist()
        {
            var idUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await usersRepo.Get(idUser);

            if (user == null)
                return Unauthorized();

            var playlist = await repo.GetUsersMainPlaylist(idUser);

            if (playlist == null)
                return BadRequest();

            return Ok(playlist.ToPlaylistDTO());
        }

        [HttpPost("{idSong}")]
        public async Task<IActionResult> AddSongToMainPlaylist([FromBody]AddRemoveSongDTO dto)
        {   
            var idUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await usersRepo.Get(idUser);

            if (user == null)
            {
                return Unauthorized();
            }

            if (!(await songsRepo.Find(s => s.Id == dto.IdSong)).Any())
            {
                return NoContent();
            }
            try
            {
                await repo.AddSongToMainPlaylist(idUser, dto.IdSong);
            }
            catch (System.ArgumentException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{idSong}")]
        public async Task<IActionResult> RemoveSongFromMainPlaylist([FromBody]AddRemoveSongDTO dto)
        {
            var idUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await usersRepo.Get(idUser);

            if (user == null)
                return Unauthorized();

            if (!(await songsRepo.Find(s => s.Id == dto.IdSong)).Any())
                return NoContent();

            try
            {
                await repo.RemoveSongFromMainPlaylist(idUser, dto.IdSong);
            }
            catch (System.ArgumentException)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}