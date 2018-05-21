using AutoMapper;
using MusicApp.API.Data;
using MusicApp.API.DTOs;
using MusicApp.API.Models;

namespace MusicApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDTO, User>()
            .ForMember(dest => dest.CountryId, opt =>
            {
                opt.MapFrom(src => src.IdCountry);
            });

            CreateMap<User, UserDetailDTO>()
            .ForMember(dest => dest.Country, opt => {
                opt.MapFrom(src => src.CountryId.ToString());
            })
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.ProfilePhoto.Url);
            });

            CreateMap<Playlist, PlaylistDTO>()
            .ForMember(dest => dest.User, opt => {
                opt.MapFrom(src => new UserInfoDTO{
                    Id = src.User.Id,
                    UserName = src.User.UserName
                });
            })
            .ForMember(dest => dest.SongsCount, opt => {
                opt.MapFrom(dest => dest.Songs.Count);
            });

            CreateMap<Album, AlbumInfoDTO>()
            .ForMember(dest => dest.CoverUrl, opt => {
                opt.MapFrom(src => src.Cover.Url);
            });

            CreateMap<Album, AlbumDTO>()
            .ForMember(dest => dest.CoverUrl, opt => {
                opt.MapFrom(src => src.Cover.Url);
            });

            CreateMap<Album, AlbumDetailDTO>()
            .ForMember(dest => dest.CoverUrl, opt => {
                opt.MapFrom(dest => dest.Cover.Url);
            });

            CreateMap<Artist, ArtistDTO>()
            .ForMember(dest =>dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photo.Url);
            });

            CreateMap<Artist, ArtistDetailDTO>()
            .ForMember(dest =>dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photo.Url);
            });

            CreateMap<Artist, ArtistInfoDTO>();

            CreateMap<Song, SongAlbumListDTO>();
            
            CreateMap<Song, SongDTO>();
        }
    }
}