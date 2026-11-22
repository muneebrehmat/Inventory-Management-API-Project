using InventoryManagement_API.DTOS.PurchaseDTOs;
using InventoryManagement_API.Repositries.Interfaces;
using InventoryManagement_API.Services.Intrerfaces;

namespace InventoryManagement_API.Services.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public Task<PurchaseDtos> CreateAsync(CreatePurchase dto)
        {
            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (dto.PurchasePrice <= 0)
                throw new ArgumentException("Purchase price must be greater than zero");

            if (dto.SalePrice <= 0)
                throw new ArgumentException("Sale price must be greater than zero");
            return _purchaseRepository.CreateAsync(dto);
        }

        public Task<List<PurchaseDtos>> GetAllAsync()
        {
            return _purchaseRepository.GetAllAsync();
        }

        public Task<PurchaseDtos> GetByIdAsync(int id)
        {
            return _purchaseRepository.GetByIdAsync(id);
        }
    }
}
