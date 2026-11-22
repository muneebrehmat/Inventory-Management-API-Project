using InventoryManagement_API.DTOS.ProductDTOs;
using InventoryManagement_API.Services.Intrerfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost("Create_Product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var result = await _productService.CreateAsync(dto);
            return Ok(result);
        }
        [Authorize(Roles = "Admin,Cashier")]
        [HttpGet("Get_All_Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }
        [HttpDelete("Delete_Product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result)
            {
                return NotFound("Product not found");
            }
            return Ok("Product deleted successfully");
        }
        [Authorize(Roles = "Admin,Cashier")]
        [HttpGet("Get_Product_By_Id/{ProductCode}")]
        public async Task<IActionResult> GetProductById(string ProductCode)
        {
            var result = await _productService.GetByIdAsync(ProductCode);
            if (result == null)
            {
                return NotFound("Product not found");
            }
            return Ok(result);
        }
        [HttpPut("Update_Product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var result = await _productService.UpdateAsync(id, dto);
            if (!result)
            {
                return NotFound("Product not found");
            }
            return Ok("Product updated successfully");
        }
    }
}
