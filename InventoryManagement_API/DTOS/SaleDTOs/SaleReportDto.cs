namespace InventoryManagement_API.DTOS.SaleDTOs
{
    public class SaleReportDto
    {
        public int SaleId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}
