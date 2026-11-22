using InventoryManagement_API.Data;
using InventoryManagement_API.DTOS.StockReportDTOs;
using InventoryManagement_API.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_API.Repositries.Implementation
{
    public class StockReportRepository : IStockReportRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StockReportRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockReportDtos>> GetReportAsync()
        {
            var products = await _dbContext.Products
                .Select(p => new StockReportDtos
                {
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,

                    Purchased = _dbContext.Purchases
                        .Where(x => x.ProductId == p.Id)
                        .Sum(x => (int?)x.Quantity) ?? 0,

                    Sold = _dbContext.Sales
                        .Where(x => x.ProductId == p.Id)
                        .Sum(x => (int?)x.Quantity) ?? 0,

                    Remaining =
                        (_dbContext.Purchases
                            .Where(x => x.ProductId == p.Id)
                            .Sum(x => (int?)x.Quantity) ?? 0)
                        -
                        (_dbContext.Sales
                            .Where(x => x.ProductId == p.Id)
                            .Sum(x => (int?)x.Quantity) ?? 0)
                })
                .ToListAsync();

            return products;
        }
    }
}
