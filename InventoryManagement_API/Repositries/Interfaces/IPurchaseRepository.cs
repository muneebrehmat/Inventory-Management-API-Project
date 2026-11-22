using InventoryManagement_API.DTOS.PurchaseDTOs;

namespace InventoryManagement_API.Repositries.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseDtos>> GetAllAsync();
        Task<PurchaseDtos> CreateAsync(CreatePurchase dto);
        Task<PurchaseDtos> GetByIdAsync(int id);

    }
}
