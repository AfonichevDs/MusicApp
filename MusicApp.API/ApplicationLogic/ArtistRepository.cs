using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.API.Data;
using MusicApp.API.Models;

namespace MusicApp.API.ApplicationLogic
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(DataContext context) : base(context) {}

        public async Task<Artist> GetWithAlbums(int idArtist)
        {
            var artist = await context.Set<Artist>().Include(a => a.Albums).Include(a => a.Photo).FirstOrDefaultAsync(a => a.Id == idArtist);
            artist.Albums = await context.Set<Album>().Include(al => al.Cover).ToListAsync();
            return artist;
        }
    }
}