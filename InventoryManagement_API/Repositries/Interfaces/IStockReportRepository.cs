using InventoryManagement_API.DTOS.StockReportDTOs;

namespace InventoryManagement_API.Repositries.Interfaces
{
    public interface IStockReportRepository
    {
        Task<List<StockReportDtos>> GetReportAsync();
    }
}
