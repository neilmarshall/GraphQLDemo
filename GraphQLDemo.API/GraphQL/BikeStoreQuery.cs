using GraphQL.Types;
using GraphQLDemo.API.GraphQLModel.Types.Production;
using GraphQLDemo.Interfaces.Repository;

namespace GraphQLDemo.API.GraphQLModel
{
    public class BikeStoreQuery : ObjectGraphType
    {
        public BikeStoreQuery(IBikeStoreRepository bikeStoreRepository)
        {
            Field<ListGraphType<BrandType>>(
                "brands",
                resolve: context => bikeStoreRepository.GetProducts(1, 10));  // TODO - parameterise query and replace hardcoded values
        }
    }
}
