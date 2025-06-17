using ProductInventory.Api.Data;
using ProductInventory.Api.Models;

public class ProductRepository : IProductRepository
{

    // private List<Products> products;
    public ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        _context=applicationDbContext;
    }
    public Products Get(string id)
    {
        Products products = _context.products.Find(id);
        return products;
    }

    public List<Products> GetAll()
    {
        return _context.products.ToList<Products>();
    }

    public void Remove(string id)
    {
        var product = _context.products.Find(id);
        _context.products.Remove(product);
        _context.SaveChanges();
    }

    public Products Save(Products product)
    {
        _context.products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Products Update(string id,Products product)
    {
        _context.products.Update(product);
         _context.SaveChanges();
        return product;
    }

    
}