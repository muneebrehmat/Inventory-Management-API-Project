using InventoryManagement_API.Services.Intrerfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : ControllerBase
    {
        private readonly IStockReportService _stockReportService;
        public StockReportController(IStockReportService stockReportService)
        {
            _stockReportService = stockReportService;
        }
        [HttpGet("Get_Stock_Report")]
        public async Task<IActionResult> GetStockReport()
        {
            try
            {
                var result = await _stockReportService.GetReportAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
