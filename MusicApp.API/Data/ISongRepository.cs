using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<IEnumerable<Song>> FindWithAlbum(Expression<Func<Song, bool>> predicate);
    }
}