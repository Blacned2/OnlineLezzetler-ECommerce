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
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperDto>()
                .ForMember(dest => dest.ShipperID, act => act.MapFrom(src => src.ShipperID))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone));

            CreateMap<ShipperDto,Shipper >()
                .ForMember(dest => dest.ShipperID, act => act.MapFrom(src => src.ShipperID))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Phone, act => act.MapFrom(src => src.Phone));
        }
    }
}
