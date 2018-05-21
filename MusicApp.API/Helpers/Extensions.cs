using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MusicApp.API.Data;
using MusicApp.API.DTOs;
using MusicApp.API.Models;

namespace MusicApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Origin-Header", "*");
        }

        public static PlaylistDetailDTO ToPlaylistDTO(this Playlist playlist)
        {
            var t = playlist.Songs.Any();

            return new PlaylistDetailDTO
            {
                Name = playlist.Name,
                Description = playlist.Description,
                IsMain = playlist.IsMain,
                Username = playlist.User.UserName,
                Songs = playlist.Songs.Any() ? playlist.Songs.Select(s => new SongDTO
                {
                    Id = s.SongId,
                    Name = s.Song.Name,
                    Path = s.Song.Path,
                    Order = s.Song.Order,
                    Album = new AlbumDTO
                    {
                        Id = s.Song.AlbumId.Value,
                        Name = s.Song.Album.Name,
                        CoverUrl = s.Song.Album.Cover.Url,
                        Artist = new ArtistInfoDTO()
                        {
                            Id = s.Song.Album.ArtistId,
                            Name = s.Song.Album.Artist.Name
                        }
                    }
                }).ToList() : null
            };
        }

        public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, List<TSource> source)
        {
            return source.Select(x => mapper.Map<TDestination>(x)).ToList();
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}