using GraphQL.Types;
using GraphQLDemo.Interfaces.Models.Sales;

namespace GraphQLDemo.API.GraphQLModel.Types.Sales
{
    public class StoreType : ObjectGraphType<Store>
    {
        public StoreType()
        {
            Field(t => t.City);
            Field(t => t.Email);
            Field(t => t.Id);
            Field(t => t.Phone);
            Field(t => t.State);
            Field(t => t.StoreName);
            Field(t => t.Street);
            Field(t => t.ZipCode);
        }
    }
}
