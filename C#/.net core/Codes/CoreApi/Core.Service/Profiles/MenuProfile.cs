using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service.Profiles
{
    public class MenuProfile:Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuAddDto, Menu>();

            CreateMap<MenuUpdateDto, Menu>();

            CreateMap<Menu, MenuQueryDto>();
        }
    }
}
