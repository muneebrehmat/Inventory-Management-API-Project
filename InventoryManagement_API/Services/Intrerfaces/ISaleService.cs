using InventoryManagement_API.DTOS.SaleDTOs;

namespace InventoryManagement_API.Services.Intrerfaces
{
    public interface ISaleService
    {
        Task<SaleReportResponseDto> GetAllAsync();
        Task<string> CreateAsync(CreateSaleDto dto);
    }
}
