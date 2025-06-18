


namespace ProductInventory.Api.Models;

public interface IProductRepository{
// {
//     public Products Save(Products products);
//     public List<Products> GetAll();
//     public Products Get(string id);
//     public Products Update(string id,Products products);
//     public void Remove(string id);
    Task<Products> AddAsync(Products product);
        Task<IEnumerable<Products>> GetProductsAsync();
        Task DeleteAsync(Guid id);
        Task<Products> GetByIdAsync(Guid id);
        Task UpdateAsync(Products product);
}