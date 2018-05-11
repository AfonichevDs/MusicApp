using AutoMapper;
using MusicApp.API.Data;
using MusicApp.API.DTOs;
using MusicApp.API.Models;

namespace MusicApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //todo sometime: add resolver for country name
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

            CreateMap<Album, AlbumInfoDTO>()
            .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Cover.Url);
            });

            CreateMap<Artist, ArtistDetailDTO>()
            .ForMember(dest =>dest.PhotoUrl, opt => {
                opt.MapFrom(src => src.Photo.Url);
            });
        }
    }
}