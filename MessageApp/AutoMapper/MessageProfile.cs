using AutoMapper;
using MessageApp.DTOs;
using MessageApp.Models;

namespace MessageApp.AutoMapper
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageAuthorDto>();
            CreateMap<User, MessageAuthorDto>()
                .ForMember(dest => dest.IsUserAdmin, opt => opt.MapFrom(src => src.IsAdmin))
                .ForMember(dest => dest.UserLogin, opt => opt.MapFrom(src => src.Login));
        }
    }
}
