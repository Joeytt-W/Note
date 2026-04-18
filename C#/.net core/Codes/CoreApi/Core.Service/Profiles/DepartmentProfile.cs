using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentAddDto, Department>();

            CreateMap<DepartmentUpdateDto, Department>();

            CreateMap<Department, DepartmentQueryDto>();
        }
    }
}
