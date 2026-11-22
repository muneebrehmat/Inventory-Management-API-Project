namespace InventoryManagement_API.DTOS.ProductDTOs
{
    public class CreateProductDto
    {
       
        public string ProductCode { get; set; }

        
        public string ProductName { get; set; } 

        public string? Description { get; set; }

        
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        
        public int StockQuantity { get; set; }
    }
}
