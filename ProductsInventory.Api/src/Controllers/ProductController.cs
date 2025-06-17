using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Services;

namespace ProductInventory.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpPost]
    public ActionResult CreateProduct([FromBody] Products product)
    {
        Products newProduct = _productService.AddProduct(product);
        return Ok(newProduct);
    }



    [HttpGet("{id}")]
    public ActionResult GetProduct(string id)
    {
        Products new1Product = _productService.GetProduct(id);
        return Ok(new1Product);
    }

    [HttpGet]
    public ActionResult GetAllProducts()
    {
        var allProducts = _productService.GetAllProducts();
        return Ok(allProducts);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(string id)
    {
        _productService.DeleteProduct(id);
        return Ok("Deleted");
    }



    [HttpPut("{id}")]
    public ActionResult UpdateProduct(string id,[FromBody] Products products)
    {
        Products updateProduct = _productService.UpdateProduct(id, products);
        return Ok(updateProduct);
    }
}