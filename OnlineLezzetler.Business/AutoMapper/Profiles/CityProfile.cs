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
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()
                .ForMember(dest => dest.CityID, act => act.MapFrom(src => src.CityID))
                .ForMember(dest => dest.CityName, act => act.MapFrom(src => src.CityName))
                .ForMember(dest => dest.PostalCode, act => act.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Region, act => act.MapFrom(src => src.Region));

            CreateMap<CityDto, City>()
                .ForMember(dest => dest.CityID, act => act.MapFrom(src => src.CityID))
                .ForMember(dest => dest.CityName, act => act.MapFrom(src => src.CityName))
                .ForMember(dest => dest.PostalCode, act => act.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Region, act => act.MapFrom(src => src.Region));
        }
    }
}
