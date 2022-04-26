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
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dest => dest.ProductID, act => act.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.DetailID, act => act.MapFrom(src => src.DetailID)) 
                .ForMember(dest => dest.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount));

            CreateMap<OrderDetailDto, OrderDetail>()
                .ForMember(dest => dest.ProductID, act => act.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.DetailID, act => act.MapFrom(src => src.DetailID)) 
                .ForMember(dest => dest.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Discount, act => act.MapFrom(src => src.Discount));
                
        }
    }
}
