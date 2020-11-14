using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Production
{
    public class Stock
    {
        [DataColumn("store_id")]
        public int Id { get; set; }
        [DataColumn("product_id")]
        public int ProductId { get; set; }
        [DataColumn("quantity")]
        public int Quantity { get; set; }
    }
}

