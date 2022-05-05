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
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CustomerID, act => act.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.CityID, act => act.MapFrom(src => src.CityID))
                .ForMember(dest => dest.CustomerName, act => act.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Fax, act => act.MapFrom(src => src.Fax))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone));

            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.CustomerID, act => act.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.CityID, act => act.MapFrom(src => src.CityID))
                .ForMember(dest => dest.CustomerName, act => act.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Fax, act => act.MapFrom(src => src.Fax))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone));
        }
    }
}
