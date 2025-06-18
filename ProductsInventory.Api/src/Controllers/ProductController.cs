using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Data.Requests;
using ProductInventory.Api.Data.Responses;
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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var result = await _productService.CreateProduct(request);
        if (result == null)
        {
            return BadRequest(new ApiResponse<ProductDto>(false, "Product Creation Failed", null));
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, new ApiResponse<ProductDto>(true, "Product Created Successfully", result));
    }


    // Get List of Products
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAll();
        return Ok(new ApiResponse<IEnumerable<ProductDto>>(true, "Products Fetched Successfully", result));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productService.GetById(id);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Fetched Successfully", result));
    }

     // Update a Product
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
    {
        var result = await _productService.UpdateProduct(id, request);
        if (result == null)
        {
            return NotFound(new ApiResponse<ProductDto>(false, "Product Not Found", null));
        }
        return Ok(new ApiResponse<ProductDto>(true, "Product Updated Successfully", result));
    }

    // Delete a Product
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var result = await _productService.DeleteProductAsync(id);
        if (!result)
        {
            return NotFound(new ApiResponse<bool>(false, "Product Not Found", false));
        }
        return Ok(new ApiResponse<bool>(true, "Product Deleted Successfully", true));
    }



    // [HttpPost]
    // public ActionResult CreateProduct([FromBody] Products product)
    // {
    //     Products newProduct = _productService.AddProduct(product);
    //     return Ok(newProduct);
    // }



    // [HttpGet("{id}")]
    // public ActionResult GetProduct(string id)
    // {
    //     Products new1Product = _productService.GetProduct(id);
    //     return Ok(new1Product);
    // }

    // [HttpGet]
    // public ActionResult GetAllProducts()
    // {
    //     var allProducts = _productService.GetAllProducts();
    //     return Ok(allProducts);
    // }

    // [HttpDelete("{id}")]
    // public ActionResult DeleteProduct(string id)
    // {
    //     _productService.DeleteProduct(id);
    //     return Ok("Deleted");
    // }



    // [HttpPut("{id}")]
    // public ActionResult UpdateProduct(string id,[FromBody] Products products)
    // {
    //     Products updateProduct = _productService.UpdateProduct(id, products);
    //     return Ok(updateProduct);
    // }
}