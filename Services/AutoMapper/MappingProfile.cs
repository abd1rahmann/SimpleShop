using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            // Order mappings
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderItemDto, OrderItem>();
        }
    }
}
