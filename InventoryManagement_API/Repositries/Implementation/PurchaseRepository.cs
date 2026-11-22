using InventoryManagement_API.Data;
using InventoryManagement_API.DTOS.PurchaseDTOs;
using InventoryManagement_API.Models;
using InventoryManagement_API.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_API.Repositries.Implementation
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PurchaseDtos> CreateAsync(CreatePurchase dto)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p=>p.ProductCode == dto.ProductCode);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            var supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.SupplierCode == dto.SupplierCode);
            if(supplier == null)
            {
                throw new KeyNotFoundException("Supplier not found");
            }
            product.StockQuantity += dto.Quantity;
            product.PurchasePrice = dto.PurchasePrice;
            product.UnitPrice = dto.SalePrice;
            var purchase = new Purchase
            {
                ProductId = product.Id,
                SupplierId = supplier.Id,
                Quantity = dto.Quantity,
                PurchasePrice = dto.PurchasePrice,
                
                TotalAmount = dto.Quantity * dto.PurchasePrice

            };
            _dbContext.Purchases.Add(purchase);
            await _dbContext.SaveChangesAsync();
            return new PurchaseDtos
            {
                PurchaseId = purchase.Id,
                ProductCode = product.ProductCode,
                SupplierCode = supplier.SupplierCode,
                Quantity = purchase.Quantity,
                PurchasePrice = purchase.PurchasePrice,
                TotalAmount = purchase.TotalAmount,
                PurchaseDate = purchase.PurchaseDate
            };
        }

        public async Task<List<PurchaseDtos>> GetAllAsync()
        {
            return await _dbContext.Purchases
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .Select(p => new PurchaseDtos
                {
                    PurchaseId = p.Id,
                    ProductCode = p.Product.ProductCode,
                    SupplierCode = p.Supplier.SupplierCode,
                    Quantity = p.Quantity,
                    PurchasePrice = p.PurchasePrice,
                    TotalAmount = p.TotalAmount,
                    PurchaseDate = p.PurchaseDate
                })
                .ToListAsync();
        }

        public async Task<PurchaseDtos> GetByIdAsync(int id)
        {
            var purchase = await _dbContext.Purchases
                .Include(p => p.Product)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (purchase == null)
            {
                throw new KeyNotFoundException("Purchase not found");
            }

            return new PurchaseDtos
            {
                PurchaseId = purchase.Id,
                ProductCode = purchase.Product.ProductCode,
                SupplierCode = purchase.Supplier.SupplierCode,
                Quantity = purchase.Quantity,
                PurchasePrice = purchase.PurchasePrice,
                TotalAmount = purchase.TotalAmount,
                PurchaseDate = purchase.PurchaseDate
            };
        }
    }
}
