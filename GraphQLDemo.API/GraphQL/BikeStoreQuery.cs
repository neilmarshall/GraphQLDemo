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
                resolve: context => bikeStoreRepository.GetBrands());
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => bikeStoreRepository.GetProducts(1, 4));
        }
    }
}
