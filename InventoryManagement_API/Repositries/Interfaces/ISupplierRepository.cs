using InventoryManagement_API.DTOS.SupplierDtos;

namespace InventoryManagement_API.Repositries.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<SupplierDto>> GetAllAsync();
        Task<SupplierDto?> GetByIdAsync(int id);
        Task<SupplierDto> CreateAsync(CreateSupplierDto dto);

        Task<bool> UpdateAsync(int id, UpdateSupplierDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
