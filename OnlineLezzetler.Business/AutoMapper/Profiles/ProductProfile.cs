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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductID, act => act.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.CategoryID, act => act.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.SupplierID, act => act.MapFrom(src => src.SupplierID))
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.UnitInStock, act => act.MapFrom(src => src.UnitInStock))
                .ForMember(dest => dest.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.UnitOnOrder, act => act.MapFrom(src => src.UnitOnOrder))
                .ForMember(dest => dest.DisContinued, act => act.MapFrom(src => src.DisContinued));

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductID, act => act.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.CategoryID, act => act.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.SupplierID, act => act.MapFrom(src => src.SupplierID))
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.UnitInStock, act => act.MapFrom(src => src.UnitInStock))
                .ForMember(dest => dest.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.UnitOnOrder, act => act.MapFrom(src => src.UnitOnOrder))
                .ForMember(dest => dest.DisContinued, act => act.MapFrom(src => src.DisContinued));

        }
    }
}
