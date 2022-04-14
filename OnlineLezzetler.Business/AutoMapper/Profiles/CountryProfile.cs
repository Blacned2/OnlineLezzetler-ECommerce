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
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.CountryID, act => act.MapFrom(src => src.CountryID))
                .ForMember(dest => dest.CountryName, act => act.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.CountryShortName, act => act.MapFrom(src => src.CountryShortName));

            CreateMap<CountryDto, Country>()
                .ForMember(dest => dest.CountryID, act => act.MapFrom(src => src.CountryID))
                .ForMember(dest => dest.CountryName, act => act.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.CountryShortName, act => act.MapFrom(src => src.CountryShortName));

        }
    }
}
