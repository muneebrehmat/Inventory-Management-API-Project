using InventoryManagement_API.DTOS.StockReportDTOs;

namespace InventoryManagement_API.Services.Intrerfaces
{
    public interface IStockReportService
    {
        Task<List<StockReportDtos>> GetReportAsync();

    }
}
