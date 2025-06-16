using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Services;

namespace ProductInventory.Controllers;

[ApiController]
[Route("[api/Controller]")]
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


    public ActionResult GetAllProducts()
    {
        List<Products> allProducts = _productService.GetAllProducts();
        return Ok(allProducts);
    }


    public ActionResult DeleteProduct(string id)
    {
        _productService.DeleteProduct(id);
        return NoContent();

    }



    [HttpPut("{id}")]
    public ActionResult UpdateProduct([FromBody] Products products)
    {
        Products updateProduct = _productService.UpdateProduct(products);
        return Ok(updateProduct);
    }
}