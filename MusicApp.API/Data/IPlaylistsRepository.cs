using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface IPlaylistsRepository: IRepository<Playlist>
    {
        Task<Playlist> GetUsersMainPlaylist(int idUser);
        Task<IEnumerable<Song>> GetPlaylistSongs(int idPlaylist);
    }
}