using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface IPlaylistsRepository: IRepository<Playlist>
    {
        Task<Playlist> GetUsersMainPlaylist(int idUser);
        Task<IEnumerable<Song>> GetPlaylistSongs(int idPlaylist);
        Task AddSongToMainPlaylist(int idUser, int idSong);
        Task RemoveSongFromMainPlaylist(int idUser, int idSong);
        Task<IEnumerable<Playlist>> FindWithUsers(Expression<Func<Playlist, bool>> predicate);
        Task<IEnumerable<Artist>> GetPlaylistArtists(int idPlaylist);
    }
}