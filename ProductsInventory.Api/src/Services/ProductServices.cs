
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Data.Requests;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Services;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateProduct(CreateProductRequest createProduct)
    {
        Products product = _mapper.Map<Products>(createProduct);
        await _productRepository.AddAsync(product);
        var productDto = _mapper.Map<ProductDto>(product);          //Refer note
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetProductsAsync();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> GetById(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }
     public async Task<ProductDto> UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return null;
        }

        _mapper.Map(request, product);
        await _productRepository.UpdateAsync(product);

        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id);
        if(product is null)
        {
            return false;
        }
        await _productRepository.DeleteAsync(id);
        return true;

    }





    // public Products AddProduct(Products products)
    // {
    //     return _productRepository.Save(products);
    // }

    // public void  DeleteProduct(string id)
    // {       
    //     Products productss = _productRepository.Get(id);
    //     if (productss == null)
    //     {
    //         throw new Exception();
    //     }
    //     _productRepository.Remove(id);
    // }

    // public List<Products> GetAllProducts()
    // {
    //    return  _productRepository.GetAll();
    // }

    // public Products GetProduct(string id)
    // {
    //     return _productRepository.Get(id);
    // }

    // public Products UpdateProduct(string id, Products products)
    // {
    //     Products products1 = _productRepository.Get(id);
    //     if (products1 == null)
    //     {
    //         throw new Exception();
    //     }
    //     if (products.Name != "")
    //     {
    //         products1.Name = products.Name;
    //     }
    //     Products UP = _productRepository.Update(id,products1);
    //     return UP;
    // }

}