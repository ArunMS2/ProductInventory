namespace ProductInventory.Api.Services
{
    public interface IProductService
    {
        public Products GetProduct(string id);

        public Products AddProduct(Products products);

        public List<Products> GetAllProducts();

        public void  DeleteProduct(string id);

        public Products UpdateProduct(string id, Products products);
    }
}
