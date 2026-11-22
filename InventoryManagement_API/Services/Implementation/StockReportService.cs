using InventoryManagement_API.DTOS.StockReportDTOs;
using InventoryManagement_API.Repositries.Interfaces;
using InventoryManagement_API.Services.Intrerfaces;

namespace InventoryManagement_API.Services.Implementation
{
    public class StockReportService : IStockReportService
    {
        private readonly IStockReportRepository _stockReportRepository;

        public StockReportService(IStockReportRepository stockReportRepository)
        {
            _stockReportRepository = stockReportRepository;
        }

        public Task<List<StockReportDtos>> GetReportAsync()
        {
            return _stockReportRepository.GetReportAsync();
        }
    }
}
