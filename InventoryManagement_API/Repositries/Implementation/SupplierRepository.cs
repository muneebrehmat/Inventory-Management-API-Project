using InventoryManagement_API.Data;
using InventoryManagement_API.DTOS.SupplierDtos;
using InventoryManagement_API.Models;
using InventoryManagement_API.Repositries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement_API.Repositries.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
        {
            var supplier = new Supplier
            {
                SupplierCode = dto.SupplierCode,
                SupplierName = dto.SupplierName,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email,
               
                
            };
            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();
            return new SupplierDto
            {
                Id = supplier.Id,
                SupplierCode = supplier.SupplierCode,
                SupplierName = supplier.SupplierName,
                ContactNumber = supplier.ContactNumber,
                Email = supplier.Email,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var supplier = _dbContext.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return false;
            }
            _dbContext.Suppliers.Remove(supplier);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            return await _dbContext.Suppliers.Select(s => new SupplierDto
            {
                Id = s.Id,
                SupplierCode = s.SupplierCode,
                SupplierName = s.SupplierName,
                ContactNumber = s.ContactNumber,
                Email = s.Email
            }).ToListAsync();
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var supplier =await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null)
            {
                throw new KeyNotFoundException("Supplier not found");
            }
            return new SupplierDto
            {
                Id = supplier.Id,
                SupplierCode = supplier.SupplierCode,
                SupplierName = supplier.SupplierName,
                ContactNumber = supplier.ContactNumber,
                Email = supplier.Email,
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateSupplierDto dto)
        {
            var supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null)
            {
                return false;
            }
            supplier.SupplierCode = dto.SupplierCode;
            supplier.SupplierName = dto.SupplierName;
            supplier.ContactNumber = dto.ContactNumber;
            supplier.Email = dto.Email;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
