using GraphQL.Types;
using GraphQLDemo.API.GraphQLModel.Types.Production;
using GraphQLDemo.API.GraphQLModel.Types.Sales;

namespace GraphQLDemo.API.GraphQLModel
{
    public class BikeStoreQuery : ObjectGraphType
    {
        public BikeStoreQuery()
        {
            Field<ProductionQuery>("production", resolve: ctx => new { });
            Field<SalesQuery>("sales", resolve: ctx => new { });
        }
    }
}
