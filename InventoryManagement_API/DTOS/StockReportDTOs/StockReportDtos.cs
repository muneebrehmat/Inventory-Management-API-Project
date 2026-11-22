namespace InventoryManagement_API.DTOS.StockReportDTOs
{
    public class StockReportDtos
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Purchased { get; set; }
        public int Sold { get; set; }
        public int Remaining { get; set; }
    }
}
