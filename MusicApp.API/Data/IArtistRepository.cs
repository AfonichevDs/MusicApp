using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> GetWithAlbums(int idArtist);
    }
}