using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.API.Data;
using MusicApp.API.DTOs;
using MusicApp.API.Helpers;
using MusicApp.API.Models;

namespace MusicApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ArtistsController : Controller
    {
        private readonly IArtistRepository repository;
        private readonly IMapper mapper;
        public ArtistsController(IArtistRepository _repository, IMapper _mapper)
        {
            mapper = _mapper;
            repository = _repository;
        }

        [HttpGet("{idArtist}")]
        public async Task<IActionResult> GetArtist([FromQuery]int idArtist)
        {
            var artist = await repository.GetWithAlbums(idArtist);
            var artistDto = mapper.Map<ArtistDetailDTO>(artist);
            return Ok(artistDto);
        }
    }
}