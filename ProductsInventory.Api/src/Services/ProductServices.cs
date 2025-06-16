
using System.Reflection.Metadata.Ecma335;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Services;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Products AddProduct(Products products)
    {
        return _productRepository.Save(products);
    }

    public void  DeleteProduct(string id)
    {

        
        Products productss = _productRepository.Get(id);
        if (productss == null)
        {
            throw new ResourceNotFoundException();
        }
        _productRepository.Remove(id);

    }

    public List<Products> GetAllProducts()
    {
       return  _productRepository.GetAll();
    }

    public Products GetProduct(string id)
    {
        return _productRepository.Get(id);
    }

    public Products UpdateProduct(string id, Products products)
    {
        Products products1 = _productRepository.Get(id);
        if (products1 == null)
        {
            throw new ResourceNotFoundException();
        }
        if (products.Name != "")
        {
            products1.Name = products.Name;
        }
        Products UP = _productRepository.Save(products1);
        return UP;
    }

    Products IProductService.DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }
}