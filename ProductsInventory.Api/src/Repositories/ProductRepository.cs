using ProductInventory.Api.Models;

public class ProductRepository : IProductRepository
{

    private List<Products> products;
    public ProductRepository()
    {
        products = new List<Products>();
    }
    public Products Get(string id)
    {
        var product = products.Find(product => product.Id == id);
        return product;
    }

    public List<Products> GetAll()
    {
        return products;
    }

    public void Remove(string id)
    {
        var product = products.Find(product => product.Id == id);
        products.Remove(product);
        
    }

    public Products Save(Products product)
    {
        products.Add(product);
        return product;
    }

    public Products Update(string id,Products product)
    {
        products.Add(product);
        return product;
    }


    Products IProductRepository.Remove(string id)
    {
        throw new NotImplementedException();
    }
}