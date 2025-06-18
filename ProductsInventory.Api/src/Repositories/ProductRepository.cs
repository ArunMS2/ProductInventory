using Microsoft.EntityFrameworkCore;
using ProductInventory.Api.Data;
using ProductInventory.Api.Models;

public class ProductRepository : IProductRepository
{

    // private List<Products> products;
    public ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    // public Products Get(string id)
    // {
    //     Products products = _context.products.Find(id);
    //     return products;
    // }

    // public List<Products> GetAll()
    // {
    //     return _context.products.ToList<Products>();
    // }

    // public void Remove(string id)
    // {
    //     var product = _context.products.Find(id);
    //     _context.products.Remove(product);
    //     _context.SaveChanges();
    // }

    // public Products Save(Products product)
    // {
    //     _context.products.Add(product);
    //     _context.SaveChanges();
    //     return product;
    // }

    // public Products Update(string id,Products product)
    // {
    //     _context.products.Update(product);
    //      _context.SaveChanges();
    //     return product;
    // }
    


     public async Task<Products> AddAsync(Products product)
    {
        await _context.products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Products>> GetProductsAsync()
    {
        return await _context.products.ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _context.products.FindAsync(id);
        if (product is null)
        {
            return;
        }

        _context.products.Remove(product);
        await _context.SaveChangesAsync();
        return;
    }



    public async Task<Products> GetByIdAsync(Guid id)
    {
        return await _context.products.FindAsync(id)!;
    }

    public async Task UpdateAsync(Products product)
    {
        var existingProduct = await _context.products.FindAsync(product.Id);
        if (existingProduct is null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();
    }

    
}