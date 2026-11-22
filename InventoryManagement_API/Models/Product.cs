namespace InventoryManagement_API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string? Description { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal UnitPrice { get; set; }

        public int StockQuantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
