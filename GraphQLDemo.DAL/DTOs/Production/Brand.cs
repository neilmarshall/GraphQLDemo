using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Production
{
    public class Brand
    {
        [DataColumn("brand_id")]
        public int Id { get; set; }
        [DataColumn("brand_name")]
        public string BrandName { get; set; }
    }
}
