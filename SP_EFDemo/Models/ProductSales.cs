namespace SP_EFDemo.Models
{
    public class ProductSales
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription {  get; set; } = string.Empty;
        public int Qty { get; set; }
        public Decimal Price { get; set; }

    }
}
