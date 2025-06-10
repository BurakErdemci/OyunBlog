using AutoMapper;
using Core.Concretes.Entities;
using Core.Concretes.DTOs;

namespace BusinessLogic.Services
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<ForumTopic, ForumTopicDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
} 