namespace InventoryManagement_API.DTOS.PurchaseDTOs
{
    public class CreatePurchase
    {
        public string ProductCode { get; set; }
        public string SupplierCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
       
        
       

    }
}
