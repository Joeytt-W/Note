using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Service.Hepler;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();

            CreateMap<UserUpdateDto, User>();

            CreateMap<User, UserQueryDto>()
                .ForMember(dest => dest.Department,opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Roles,opt => opt.MapFrom(src => src.Roles));

            CreateMap<IQueryable<User>, IQueryable<UserQueryDto>>();
        }
    }
}
