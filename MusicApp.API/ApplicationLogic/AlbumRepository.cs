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
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(DataContext context) : base(context) { }

        public async Task<Album> GetWithSongs(int id) =>
            await context.Set<Album>().Include(a => a.Songs).Include(a => a.Cover).FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Album>> FindWithArtist(Expression<Func<Album, bool>> predicate) =>
            await context.Set<Album>().Where(predicate).Include(a => a.Artist).Include(a => a.Cover).ToListAsync();
    }
}