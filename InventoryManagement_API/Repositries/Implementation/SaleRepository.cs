using InventoryManagement_API.Data;
using InventoryManagement_API.DTOS.SaleDTOs;
using InventoryManagement_API.Models;
using InventoryManagement_API.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_API.Repositries.Implementation
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SaleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> CreateAsync(CreateSaleDto dto)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductCode == dto.ProductCode);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            if (product.StockQuantity < dto.Quantity)
            {
                throw new InvalidOperationException("Insufficient stock quantity");
            }
            product.StockQuantity -= dto.Quantity;
            var sale = new Sale
            {
                ProductId = product.Id,
                ProductCode = dto.ProductCode,
                ProductName = product.ProductName,
                Quantity = dto.Quantity,
                SalePrice = product.UnitPrice,
                TotalPrice = dto.Quantity * product.UnitPrice
            };
            _dbContext.Sales.Add(sale);
            await _dbContext.SaveChangesAsync();
            return "Sale created successfully.";
        }

        public async Task<SaleReportResponseDto> GetAllAsync()
        {
            var sales = await _dbContext.Sales
                .Include(s => s.Product)
                .Select(s => new SaleReportDto
                {
                    SaleId = s.Id,
                    ProductCode = s.Product.ProductCode,
                    ProductName = s.Product.ProductName,
                    Quantity = s.Quantity,
                    SalePrice = s.SalePrice,
                    TotalPrice = s.TotalPrice,
                    SaleDate = s.SaleDate
                })
                .ToListAsync();

            var totalSaleAmount = await _dbContext.Sales
                .SumAsync(s => (decimal?)s.TotalPrice) ?? 0;

            return new SaleReportResponseDto
            {
                Sales = sales,
                TotalSaleAmount = totalSaleAmount
            };
        }
    }
}
