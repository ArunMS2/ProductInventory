using ProductInventory.Api.Models;

namespace ProductInventory.Api.Data.Requests;
 public class UpdateProductRequest
{
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }

    public List<Category>? Categories { get; set; }
}