using AutoMapper;
using dotnet_api.Models.Dtos;
using dotnet_api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace dotnet_api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, Customer>()
               .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Product, ProductDto> ();
            CreateMap<Order_Product, Order_Product>();
            CreateMap<Orders[], Orders[]>();
        }

    }
}
