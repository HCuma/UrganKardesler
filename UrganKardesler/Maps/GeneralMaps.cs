using AutoMapper;
using UrganKardesler.Models;
using UrganKardesler.ViewModels;

namespace UrganKardesler.Maps
{
    public class GeneralMaps : Profile
    {
        public GeneralMaps()
        {
            CreateMap<Blog, BlogVM>()
            .ForMember(dest => dest.AuthorName, memb => memb.MapFrom(src => src.IdentityUser.UserName)).ReverseMap();
        }
    }
}