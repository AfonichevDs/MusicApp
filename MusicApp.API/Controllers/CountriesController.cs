using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.API.Data;

namespace MusicApp.API.Controllers
{   
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository repo;
        public CountriesController(ICountryRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries() =>
           Ok(await repo.GetAll());
    }
}