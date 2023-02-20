using AutoMapper;
using UrganKardesler.DTOs;
using UrganKardesler.Models;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Maps
{
    public class GeneralMaps : Profile
    {
        public GeneralMaps()
        {
            CreateMap<Blog, BlogVM>()
                .ForMember(dest => dest.AuthorName, memb => memb.MapFrom(src => src.IdentityUser.UserName))
                .ReverseMap()
                .ForMember(dest => dest.IdentityUser, memb => memb.Ignore());

            CreateMap<Blog, BlogDTO>()
                .ForMember(dest => dest.AuthorName, memb => memb.MapFrom(src => src.IdentityUser.UserName))
                .ForMember(dest => dest.ThumbnailBase64Code, memb => memb.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.IdentityUser, memb => memb.Ignore());

            CreateMap<BlogVM, BlogDTO>()
                .ForMember(dest => dest.ThumbnailBase64Code, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}