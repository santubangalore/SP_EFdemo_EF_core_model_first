namespace SP_EFDemo.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public Decimal Price { get; set; }  

        public int Qty { get; set; }
        //public DateTime SalesDate { get; set; }
    }
}
