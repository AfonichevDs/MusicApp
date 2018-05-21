using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.API.Data;
using MusicApp.API.Models;

namespace MusicApp.API.ApplicationLogic
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(DataContext context) : base(context) {}

        public async Task<IEnumerable<Artist>> FindWithPhoto(Expression<Func<Artist, bool>> predicate) =>
               await context.Set<Artist>().Where(predicate).Include(p => p.Photo).ToListAsync();

        public async Task<Artist> GetWithAlbums(int idArtist)
        {
            var artist = await context.Set<Artist>()
                      .Include(a => a.Photo)
                      .Include(a => a.Albums)
                      .ThenInclude(al => al.Cover)
                      .FirstOrDefaultAsync(a => a.Id == idArtist);
            return artist;
        }
    }
}