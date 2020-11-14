using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Interfaces.Models.Sales
{
    public class Staff
    {
        public int StaffId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public int StoreId { get; set; }
        public int ManagerId { get; set; }
    }
}

