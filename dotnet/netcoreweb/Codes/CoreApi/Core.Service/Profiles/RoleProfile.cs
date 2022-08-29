using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service.Profiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleAddDto, Role>();

            CreateMap<RoleUpdateDto, Role>();

            CreateMap<Role, RoleQueryDto>();

            CreateMap<ICollection<Role>, ICollection<RoleQueryDto>>();
        }
    }
}
