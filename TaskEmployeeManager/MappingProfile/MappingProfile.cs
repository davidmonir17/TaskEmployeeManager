using AutoMapper;
using Domain.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace TaskEmployeeManager.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, EmpTasksDTO>()
                .ForMember(x => x.statuesName, opt => opt.MapFrom(x => x.statues.Name))
                .ForMember(x => x.MangerName, opt => opt.MapFrom(x => x.manger.Name))
                .ReverseMap();

            CreateMap<Task, UpdateEmpTaskDTO>().ReverseMap();

            CreateMap<Employee, mgrAddEmp>().ReverseMap();
            CreateMap<Employee, mgrEmpDetailsDto>().ReverseMap();
        }
    }
}