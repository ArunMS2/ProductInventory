using System;
using AutoMapper;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Data.Requests;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Products, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequest, Products>();
        CreateMap<UpdateProductRequest, Products>();
    }

}