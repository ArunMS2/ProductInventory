using Microsoft.AspNetCore.Mvc;
using ProductInventory.Controllers;

public class ProductControllerTests
{
    [Fact]

    public void ProductAdd_ShouldReturnOk()
    {
        ProductController productController = new ProductController();
        var result = productController.CreateProduct(new Products("123", "Wheat", 10, 120.00));
        Assert.IsType<OkObjectResult>(result);
    }
    [Fact]
    public void ProductGet_ShouldReturn()
    {
        ProductController productController = new ProductController();
        var result = productController.GetProduct("123");
        Assert.IsType<OkResult>(result);
    }
}