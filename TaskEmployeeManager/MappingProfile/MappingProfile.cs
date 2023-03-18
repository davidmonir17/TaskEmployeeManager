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
            CreateMap<Employee, mgrEmpDto>().ForMember(x => x.departmentName, opt => opt.MapFrom(X => X.depertment.Name))
                .ReverseMap();

            CreateMap<Employee, mgrUpdEmpDto>().ReverseMap();

            CreateMap<Task, MgrAddTaskDto>().ReverseMap();
            CreateMap<Task, MgrTaskDetials>()
                .ForMember(x => x.EmployeeName, opt => opt.MapFrom(x => x.employee.Name))
                 .ForMember(x => x.statues, opt => opt.MapFrom(x => x.statues.Name))
                .ForMember(x => x.ManagerName, opt => opt.MapFrom(x => x.manger.Name))
                .ReverseMap();

            CreateMap<Task, MgrUpdTaskDto>().ReverseMap();
            CreateMap<Depertment, DepertmentDto>()
                .ForMember(x => x.ManagerName, opt => opt.MapFrom(x => x.manger.Name)).ReverseMap();

            CreateMap<Depertment, AddDepDTo>().ReverseMap();

            CreateMap<Employee, addMngrDto>().ReverseMap();
        }
    }
}