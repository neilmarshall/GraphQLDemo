using GraphQL.Types;
using GraphQLDemo.Interfaces.Models.Production;

namespace GraphQLDemo.API.GraphQLModel.Types.Production
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(t => t.Id);
            Field(t => t.ProductName).Description("The name of the product");
            Field(t => t.BrandId);
            Field(t => t.CategoryId);
            Field(t => t.ModelYear);
            Field(t => t.ListPrice);
        }
    }
}
