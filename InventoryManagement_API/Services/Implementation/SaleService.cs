using InventoryManagement_API.DTOS.SaleDTOs;
using InventoryManagement_API.Repositries.Interfaces;
using InventoryManagement_API.Services.Intrerfaces;

namespace InventoryManagement_API.Services.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public Task<string> CreateAsync(CreateSaleDto dto)
        {
            return _saleRepository.CreateAsync(dto);
        }

        public Task<SaleReportResponseDto> GetAllAsync()
        {
            return _saleRepository.GetAllAsync();
        }
    }
}
