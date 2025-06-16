
namespace ProductInventory.Api.Models;

public interface IProductRepository
{
    public Products Save(Products products);
    public List<Products> GetAll();
    public Products Get(string id);
    public Products Update(string id,Products products);
    public Products Remove(string id);

}