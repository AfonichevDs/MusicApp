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
    public class SongsRepository : Repository<Song>, ISongRepository
    {
        public SongsRepository(DataContext context): base(context) {}

        public async Task<IEnumerable<Song>> FindWithAlbum(Expression<Func<Song, bool>> predicate) 
        {
            var songs = await context.Set<Song>().Where(predicate).Include(s => s.Album).ThenInclude(a =>a.Artist).ToListAsync();
            songs.ForEach(song => {
                song.Album = context.Set<Album>().Include(a => a.Cover).FirstOrDefault(a => a.Id == song.AlbumId);
            });
            return songs;
        }

    }
}