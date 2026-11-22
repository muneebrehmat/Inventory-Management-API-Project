using InventoryManagement_API.DTOS.SaleDTOs;

namespace InventoryManagement_API.Repositries.Interfaces
{
    public interface ISaleRepository
    {
        Task<SaleReportResponseDto> GetAllAsync();
        Task<string> CreateAsync(CreateSaleDto dto);
    }
}
