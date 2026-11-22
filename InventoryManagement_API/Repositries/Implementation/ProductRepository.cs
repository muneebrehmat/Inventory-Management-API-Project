
using InventoryManagement_API.Data;
using InventoryManagement_API.DTOS.ProductDTOs;
using InventoryManagement_API.Models;
using InventoryManagement_API.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_API.Repositries.Implementation

{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                ProductCode = dto.ProductCode,
                ProductName = dto.ProductName,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                PurchasePrice = dto.PurchasePrice,
                StockQuantity = dto.StockQuantity
               
            };
            _dbContext.Add(product);
            await _dbContext.SaveChangesAsync();
            return new ProductDto
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                PurchasePrice = product.PurchasePrice,
                StockQuantity = product.StockQuantity,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _dbContext.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                StockQuantity = p.StockQuantity,
                CreatedAt = p.CreatedAt
            }).ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(string ProductCode)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.ProductCode == ProductCode);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                StockQuantity = product.StockQuantity,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
           var product = await _dbContext.Products.FirstOrDefaultAsync(p=>p.Id == id);
            if (product == null)
            {
                return false;
            }
            product.ProductCode = dto.ProductCode;
            product.ProductName = dto.ProductName;
            product.Description = dto.Description;
            product.UnitPrice = dto.UnitPrice;
            product.StockQuantity = dto.StockQuantity;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
