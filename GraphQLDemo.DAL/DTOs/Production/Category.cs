using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Production
{
    public class Category
    {
        [DataColumn("category_id")]
        public int Id { get; set; }
        [DataColumn("category_name")]
        public string CategoryName { get; set; }
    }
}

