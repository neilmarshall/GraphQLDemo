using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Interfaces.Models.Production
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}

