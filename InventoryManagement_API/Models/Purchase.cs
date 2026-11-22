namespace InventoryManagement_API.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
