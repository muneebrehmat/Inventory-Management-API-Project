using InventoryManagement_API.DTOS.PurchaseDTOs;
using InventoryManagement_API.Services.Intrerfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        public readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpPost("Create_Purchase")]
        public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchase dto)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
        [HttpGet("Get_All_Purchases")]
        public async Task<IActionResult> GetAllPurchases()
        {
            try
            {
                var result = await _purchaseService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get_Purchase_By_Id/{id}")]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            try
            {
                var result = await _purchaseService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound("Purchase not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
