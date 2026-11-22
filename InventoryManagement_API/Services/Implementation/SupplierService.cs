using InventoryManagement_API.DTOS.SupplierDtos;
using InventoryManagement_API.Repositries.Interfaces;
using InventoryManagement_API.Services.Intrerfaces;

namespace InventoryManagement_API.Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
        {
            return _supplierRepository.CreateAsync(dto);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _supplierRepository.DeleteAsync(id);
        }

        public Task<List<SupplierDto>> GetAllAsync()
        {
            return _supplierRepository.GetAllAsync();
        }

        public Task<SupplierDto?> GetByIdAsync(int id)
        {
            return _supplierRepository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(int id, UpdateSupplierDto dto)
        {
            return _supplierRepository.UpdateAsync(id, dto);
        }
    }
}
