namespace GraphQLDemo.Interfaces.Models.Sales
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
    }
}

