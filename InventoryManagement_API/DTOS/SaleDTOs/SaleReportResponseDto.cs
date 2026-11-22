namespace InventoryManagement_API.DTOS.SaleDTOs
{
    public class SaleReportResponseDto
    {
        public List<SaleReportDto> Sales { get; set; }
        public decimal TotalSaleAmount { get; set; }

    }
}
