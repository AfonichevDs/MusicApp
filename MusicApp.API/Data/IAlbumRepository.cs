using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface IAlbumRepository : IRepository<Album>
    {
         Task<Album> GetWithSongs(int id);

        Task<IEnumerable<Album>> FindWithArtist(Expression<Func<Album, bool>> predicate);
    }
}