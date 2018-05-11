using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.API.Data;
using MusicApp.API.Models;

namespace MusicApp.API.ApplicationLogic
{
    public class PlaylistsRepository : Repository<Playlist>, IPlaylistsRepository
    {
        public PlaylistsRepository(DataContext context) : base(context) { }

        public async Task<Playlist> GetUsersMainPlaylist(int idUser)
        {
            var playlist = await context.Set<Playlist>().FirstOrDefaultAsync(p => p.UserId == idUser && p.IsMain);
            if (playlist == null)
            {
                playlist = new Playlist
                {
                    IsMain = true,
                    UserId = idUser,
                    Name = "Main"
                };
                Add(playlist);
                await SaveChanges();
            }
            else
            {
                playlist.Songs = context.Set<SongPlaylist>().Include(sp => sp.Song).Where(sp => sp.PlaylistId == playlist.Id).ToList();
                foreach (var s in playlist.Songs) {
                    s.Song.Album = context.Set<Album>().Include(a => a.Artist).Include(a =>a.Cover).FirstOrDefault(p =>p.Id == s.Song.AlbumId);
                }
            }
            return playlist;
        }

        public async Task<IEnumerable<Song>> GetPlaylistSongs(int idPlaylist)
        {
            var playlist = await Get(idPlaylist);
            return playlist.Songs.Select(p => p.Song);
        }
    }
}