namespace InventoryManagement_API.DTOS.ProductDTOs
{
    public class UpdateProductDto
    {
        public string ProductCode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockQuantity { get; set; }
    }
}
