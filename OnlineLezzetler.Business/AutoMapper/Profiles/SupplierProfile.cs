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
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDto>()
                .ForMember(dest => dest.SupplierID, act => act.MapFrom(src => src.SupplierID))
                .ForMember(dest => dest.CityID, act => act.MapFrom(src => src.CityID))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.ContactName, act => act.MapFrom(src => src.ContactName))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(dest => dest.HomePage, act => act.MapFrom(src => src.HomePage))
                .ForMember(dest => dest.Fax, act => act.MapFrom(src => src.Fax));

            CreateMap<SupplierDto, Supplier>()
                .ForMember(dest => dest.SupplierID, act => act.MapFrom(src => src.SupplierID))
                .ForMember(dest => dest.CityID, act => act.MapFrom(src => src.CityID))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.ContactName, act => act.MapFrom(src => src.ContactName))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone))
                .ForMember(dest => dest.HomePage, act => act.MapFrom(src => src.HomePage))
                .ForMember(dest => dest.Fax, act => act.MapFrom(src => src.Fax));
        }
    }
}
