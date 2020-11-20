using GraphQL.Types;
using GraphQLDemo.DAL.DTOs.Production;

namespace GraphQLDemo.API.GraphQLModel.Types.Production
{
    public class BrandType : ObjectGraphType<Brand>
    {
        public BrandType()
        {
            Field(t => t.Id);
            Field(t => t.BrandName);
        }
    }
}
