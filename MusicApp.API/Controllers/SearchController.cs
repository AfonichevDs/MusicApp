using System;
using System.Linq;
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
    public class SearchController : Controller
    {
        private readonly ISongRepository songRepo;
        private readonly IAlbumRepository albumRepo;
        private readonly IArtistRepository artistRepo;
        private readonly IUsersRepository usersRepo;
        private readonly IPlaylistsRepository playlistRepo;
        private readonly IMapper mapper;

        public SearchController(ISongRepository _songRepo, IAlbumRepository _albumRepo,
                                IArtistRepository _artistRepo, IUsersRepository _usersRepo,
                                IPlaylistsRepository _playlistRepo, IMapper _mapper)
        {
            songRepo = _songRepo;
            albumRepo = _albumRepo;
            artistRepo = _artistRepo;
            usersRepo = _usersRepo;
            playlistRepo = _playlistRepo;
            mapper = _mapper;
        }

        [HttpGet("SearchByTerm")]
        public async Task<IActionResult> SearchByTerm(UserParams userParams)
        {
            var result = new SearchResult();
            var idUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await usersRepo.Get(idUser);

            if (user == null)
                return Unauthorized();

            if (userParams.SearchArtists)
                result.Artists = (await artistRepo.FindWithPhoto(a => a.Name.Contains(userParams.SearchTerm, StringComparison.OrdinalIgnoreCase)))
                                 .Select(a => mapper.Map<ArtistDTO>(a))
                                 .ToList();

            if (userParams.SearchAlbums)
                result.Albums = (await albumRepo.FindWithArtist(a => a.Name.Contains(userParams.SearchTerm, StringComparison.OrdinalIgnoreCase)))
                                 .Select(a => mapper.Map<AlbumDTO>(a))
                                 .ToList();

            if (userParams.SearchSongs)
                result.Songs = (await songRepo.FindWithAlbum(a => a.Name.Contains(userParams.SearchTerm, StringComparison.OrdinalIgnoreCase)))
                                 .Select(a => mapper.Map<SongDTO>(a))
                                 .ToList();

            if (userParams.SearchPlaylists)
            {
                result.Playlists = (await playlistRepo.FindWithUsers(a => a.Name.Contains(userParams.SearchTerm, StringComparison.OrdinalIgnoreCase)
                                              && !a.IsMain))
                 .Select(a => mapper.Map<PlaylistDTO>(a))
                 .ToList();

                foreach (var pl in result.Playlists)
                {
                    var artists = (await playlistRepo.GetPlaylistArtists(pl.Id))
                                                    .Distinct()
                                                    .Select(a => mapper.Map<ArtistInfoDTO>(a))
                                                    .ToList();
                    pl.Artists = artists;
                }
            }
            return Ok(result);
        }
    }
}