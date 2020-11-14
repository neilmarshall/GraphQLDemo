using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Sales
{
    public class Staff
    {
        [DataColumn("staff_id")]
        public int StaffId { get; set; }
        [DataColumn("first_name")]
        public string FirstName { get; set; }
        [DataColumn("last_name")]
        public string LastName { get; set; }
        [DataColumn("email")]
        public string Email { get; set; }
        [DataColumn("phone")]
        public string Phone { get; set; }
        [DataColumn("active")]
        public short Active { get; set; }
        [DataColumn("store_id")]
        public int StoreId { get; set; }
        [DataColumn("manager_id")]
        public int ManagerId { get; set; }
    }
}

