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
                foreach (var s in playlist.Songs)
                {
                    s.Song.Album = context.Set<Album>().Include(a => a.Artist).Include(a => a.Cover).FirstOrDefault(p => p.Id == s.Song.AlbumId);
                }
            }
            return playlist;
        }

        public async Task<IEnumerable<Song>> GetPlaylistSongs(int idPlaylist)
        {
            var playlist = await context.Set<Playlist>().Include(s => s.Songs)
                                                        .ThenInclude(sp =>sp.Song)
                                                        .FirstAsync(p => p.Id == idPlaylist);
            return playlist.Songs.Select(sp =>sp.Song);
        }

        public async Task AddSongToMainPlaylist(int idUser, int idSong)
        {
            var playlist = await GetUsersMainPlaylist(idUser);

            if (context.Set<SongPlaylist>().Where(s => s.SongId == idSong && s.PlaylistId == playlist.Id).Any())
            {
                throw new System.ArgumentException();
            }

            var songPlaylist = new SongPlaylist
            {
                SongId = idSong,
                PlaylistId = playlist.Id
            };

            context.Set<SongPlaylist>().Add(songPlaylist);
            await SaveChanges();
        }

        public async Task RemoveSongFromMainPlaylist(int idUser, int idSong)
        {
            var playlist = await GetUsersMainPlaylist(idUser);

            if (!context.Set<SongPlaylist>().Where(s => s.SongId == idSong && s.PlaylistId == playlist.Id).Any())
            {
                throw new System.ArgumentException();
            }

            var songPlaylist = context.Set<SongPlaylist>().First(s => s.SongId == idSong);
            context.Set<SongPlaylist>().Remove(songPlaylist);
            await SaveChanges();
        }

        public async Task<IEnumerable<Playlist>> FindWithUsers(Expression<Func<Playlist, bool>> predicate) =>
               await context.Set<Playlist>().Where(predicate).Include(p =>p.Songs).Include(p => p.User).ToListAsync();

        public async Task<IEnumerable<Artist>> GetPlaylistArtists(int idPlaylist) 
        {
            var artists = new List<Artist>();

            var songs = await GetPlaylistSongs(idPlaylist);

            foreach (var song in songs) 
            {
                song.Album = context.Set<Album>().Include(a => a.Artist).First(a => a.Id == song.AlbumId);
                artists.Add(song.Album.Artist);
            }

            return artists;
        }

    }
}