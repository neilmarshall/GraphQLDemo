using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Interfaces.Models.Sales
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}

