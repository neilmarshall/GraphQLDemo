using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Sales
{
    public class Customer
    {
        [DataColumn("customer_id")]
        public int Id { get; set; }
        [DataColumn("first_name")]
        public string FirstName { get; set; }
        [DataColumn("last_name")]
        public string LastName { get; set; }
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
        public string Zipcode { get; set; }
    }
}

