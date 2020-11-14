using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Interfaces.Models.Production
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string BrandName { get; set; }
    }
}
