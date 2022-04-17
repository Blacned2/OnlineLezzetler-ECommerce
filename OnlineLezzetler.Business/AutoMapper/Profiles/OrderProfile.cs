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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderID, act => act.MapFrom(src => src.OrderID))
                .ForMember(dest => dest.EmployeeID, act => act.MapFrom(src => src.EmployeeID))
                .ForMember(dest => dest.CustomerID, act => act.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.ShipperID, act => act.MapFrom(src => src.ShipperID))
                .ForMember(dest => dest.DetailID, act => act.MapFrom(src => src.DetailID))
                .ForMember(dest => dest.ShippedCityID, act => act.MapFrom(src => src.ShippedCityID))
                .ForMember(dest => dest.OrderDate, act => act.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.RequiredDate, act => act.MapFrom(src => src.RequiredDate))
                .ForMember(dest => dest.ShippedTime, act => act.MapFrom(src => src.ShippedDate))
                .ForMember(dest => dest.Freight, act => act.MapFrom(src => src.Freight));

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.OrderID, act => act.MapFrom(src => src.OrderID))
                .ForMember(dest => dest.EmployeeID, act => act.MapFrom(src => src.EmployeeID))
                .ForMember(dest => dest.CustomerID, act => act.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.ShipperID, act => act.MapFrom(src => src.ShipperID))
                .ForMember(dest => dest.DetailID, act => act.MapFrom(src => src.DetailID))
                .ForMember(dest => dest.ShippedCityID, act => act.MapFrom(src => src.ShippedCityID))
                .ForMember(dest => dest.OrderDate, act => act.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.RequiredDate, act => act.MapFrom(src => src.RequiredDate))
                .ForMember(dest => dest.ShippedDate, act => act.MapFrom(src => src.ShippedTime))
                .ForMember(dest => dest.Freight, act => act.MapFrom(src => src.Freight));
        }
    }
}
