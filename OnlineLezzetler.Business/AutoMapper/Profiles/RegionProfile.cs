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
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>()
                .ForMember(dest => dest.RegionID, act => act.MapFrom(src => src.RegionID))
                .ForMember(dest => dest.RegionDescription, act => act.MapFrom(src => src.RegionDescription))
                .ForMember(dest => dest.CountryID, act => act.MapFrom(src => src.CountryID));

            CreateMap<RegionDto, Region>()
                .ForMember(dest => dest.RegionID, act => act.MapFrom(src => src.RegionID))
                .ForMember(dest => dest.RegionDescription, act => act.MapFrom(src => src.RegionDescription))
                .ForMember(dest => dest.CountryID, act => act.MapFrom(src => src.CountryID));
        }
    }
}
