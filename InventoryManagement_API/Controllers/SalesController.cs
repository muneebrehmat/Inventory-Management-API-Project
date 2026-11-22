using InventoryManagement_API.DTOS.SaleDTOs;
using InventoryManagement_API.Services.Intrerfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        public readonly ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost("Create_Sale")]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto dto)
        {
            try
            {
                var result = await _saleService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get_All_Sales")]
        public async Task<IActionResult> GetAllSales()
        {
            
                var result = await _saleService.GetAllAsync();
                return Ok(result);
            
        }
    }
}
