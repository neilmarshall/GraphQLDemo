using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Sales
{
    public class Store
    {
        [DataColumn("store_id")]
        public int Id { get; set; }
        [DataColumn("store_name")]
        public string StoreName { get; set; }
        [DataColumn("phone")]
        public string Phone { get; set; }
        [DataColumn("email")]
        public string Email { get; set; }
        [DataColumn("street")]
        public string Street { get; set; }
        [DataColumn("city")]
        public string City { get; set; }
        [DataColumn("state")]
        public string State { get; set; }
        [DataColumn("zip_code")]
        public string ZipCode { get; set; }
    }
}

