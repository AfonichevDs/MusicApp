using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Data;
using MusicApp.API.DTOs;

namespace MusicApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AlbumsController : Controller
    {
        private readonly IAlbumRepository repository;
        private readonly IMapper mapper;
        public AlbumsController(IAlbumRepository _repository, IMapper _mapper)
        {
            mapper = _mapper;
            repository = _repository;
        }

        [HttpGet("{idArtist}")]
        public async Task<IActionResult> GetAlbumDetail(int idAlbum)
        {
            var album = await repository.GetWithSongs(idAlbum);
            var albumDto = mapper.Map<AlbumDetailDTO>(album);
            albumDto.Songs.OrderBy(s => s.Order);
            return Ok(albumDto);
        }
    }
}