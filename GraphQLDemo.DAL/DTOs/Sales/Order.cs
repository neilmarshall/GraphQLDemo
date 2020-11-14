using System;
using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Sales
{
    public class Order
    {
        [DataColumn("order_id")]
        public int Id { get; set; }
        [DataColumn("customer_id")]
        public int CustomerId { get; set; }
        [DataColumn("order_status")]
        public int OrderStatus { get; set; }
        [DataColumn("order_date")]
        public DateTime OrderDate { get; set; }
        [DataColumn("required_date")]
        public DateTime RequiredDate { get; set; }
        [DataColumn("shipped_date")]
        public DateTime ShippedDate { get; set; }
        [DataColumn("store_id")]
        public int StoreId { get; set; }
        [DataColumn("staff_id")]
        public int StaffId { get; set; }
    }
}

