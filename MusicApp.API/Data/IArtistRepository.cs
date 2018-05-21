using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> GetWithAlbums(int idArtist);
        Task<IEnumerable<Artist>> FindWithPhoto(Expression<Func<Artist, bool>> predicate);
    }
}