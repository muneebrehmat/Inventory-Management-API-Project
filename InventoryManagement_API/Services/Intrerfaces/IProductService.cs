using InventoryManagement_API.DTOS.ProductDTOs;

namespace InventoryManagement_API.Services.Intrerfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(string ProductCode);

        Task<ProductDto> CreateAsync(CreateProductDto dto);

        Task<bool> UpdateAsync(int id, UpdateProductDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
