using AutoMapper;
using OnlineLezzetler.Business.AutoMapper.Dtos;
using OnlineLezzetler.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLezzetler.Business.AutoMapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmployeeID, act => act.MapFrom(src => src.EmployeeID))
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(dest => dest.EmployeeCityID, act => act.MapFrom(src => src.EmployeeCityID))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.Salary, act => act.MapFrom(src => src.Salary))
                .ForMember(dest => dest.BirthDate, act => act.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.HiredDate, act => act.MapFrom(src => src.HiredDate))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Notes, act => act.MapFrom(src => src.Notes))
                .ForMember(dest => dest.PhotoPath, act => act.MapFrom(src => src.PhotoPath));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.EmployeeID, act => act.MapFrom(src => src.EmployeeID))
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LastName))
                .ForMember(dest => dest.EmployeeCityID, act => act.MapFrom(src => src.EmployeeCityID))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title))
                .ForMember(dest => dest.Salary, act => act.MapFrom(src => src.Salary))
                .ForMember(dest => dest.BirthDate, act => act.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.HiredDate, act => act.MapFrom(src => src.HiredDate))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Notes, act => act.MapFrom(src => src.Notes))
                .ForMember(dest => dest.PhotoPath, act => act.MapFrom(src => src.PhotoPath));
        }
    }
}
