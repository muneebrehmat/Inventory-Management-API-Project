using InventoryManagement_API.DTOS.ProductDTOs;
using InventoryManagement_API.Repositries.Interfaces;
using InventoryManagement_API.Services.Intrerfaces;

namespace InventoryManagement_API.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var result = await _productRepository.CreateAsync(dto);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _productRepository.DeleteAsync(id);
            return result;

        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync();
            return result;
        }

        public async Task<ProductDto?> GetByIdAsync(string ProductCode)
        {
            var result = await _productRepository.GetByIdAsync(ProductCode);
            return result;
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var result = await _productRepository.UpdateAsync(id, dto);
            return result;
        
        }
    }
}
