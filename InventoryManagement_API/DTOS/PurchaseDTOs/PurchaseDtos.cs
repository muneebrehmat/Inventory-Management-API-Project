namespace InventoryManagement_API.DTOS.PurchaseDTOs
{
    public class PurchaseDtos
    {
        public int PurchaseId { get; set; }
        public string ProductCode { get; set; }
        public string SupplierCode { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
