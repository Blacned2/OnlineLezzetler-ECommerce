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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.CategoryID, act => act.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.CategoryName, act => act.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description));

            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.CategoryID, act => act.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.CategoryName, act => act.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description));

        }
    }
}
