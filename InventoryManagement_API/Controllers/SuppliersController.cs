using InventoryManagement_API.DTOS.SupplierDtos;
using InventoryManagement_API.Services.Intrerfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpPost("Create_Supplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDto dto)
        {
            try
            {
                var result = await _supplierService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get_All_Suppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var result = await _supplierService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get_Supplier_By_Id/{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            try
            {
                var result = await _supplierService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound("Supplier not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update_Supplier/{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] UpdateSupplierDto dto)
        {
            try
            {
                var result = await _supplierService.UpdateAsync(id, dto);
                if (!result)
                {
                    return NotFound("Supplier not found.");
                }
                return Ok("Supplier updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete_Supplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                var result = await _supplierService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound("Supplier not found.");
                }
                return Ok("Supplier deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
