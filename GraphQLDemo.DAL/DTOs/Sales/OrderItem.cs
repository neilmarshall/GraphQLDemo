using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Sales
{
    public class OrderItem
    {
        [DataColumn("order_id")]
        public int Id { get; set; }
        [DataColumn("item_id")]
        public int ItemId { get; set; }
        [DataColumn("product_id")]
        public int ProductId { get; set; }
        [DataColumn("quantity")]
        public int Quantity { get; set; }
        [DataColumn("list_price")]
        public decimal ListPrice { get; set; }
        [DataColumn("discount")]
        public decimal Discount { get; set; }
    }
}

