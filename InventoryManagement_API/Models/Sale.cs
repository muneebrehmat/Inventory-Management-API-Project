namespace InventoryManagement_API.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}
