namespace InventoryManagement_API.DTOS.ProductDTOs
{
    public class ProductDto
    {
         public int Id { get; set; }

        public string ProductCode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        public int StockQuantity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
