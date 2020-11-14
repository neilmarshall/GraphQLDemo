using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL.DTOs.Production
{
    public class Product
    {
        [DataColumn("product_id")]
        public int Id { get; set; }
        [DataColumn("product_name")]
        public string ProductName { get; set; }
        [DataColumn("brand_id")]
        public int BrandId { get; set; }
        [DataColumn("category_id")]
        public int CategoryId { get; set; }
        [DataColumn("model_year")]
        public int ModelYear { get; set; }
        [DataColumn("list_price")]
        public decimal ListPrice { get; set; }
    }
}
