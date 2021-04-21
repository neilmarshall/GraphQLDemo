using GraphQL.Types;
using GraphQLDemo.API.GraphQLModel.Types.Sales;
using GraphQLDemo.Interfaces.Repository;

namespace GraphQLDemo.API.GraphQLModel.Types.Sales
{
    public class SalesQuery : ObjectGraphType
    {
        public SalesQuery(IBikeStoreRepository bikeStoreRepository)
        {
            Field<ListGraphType<StaffType>>(
                    "staff",
                    resolve: context =>
                    {
                        return bikeStoreRepository.GetStaff();
                    });

            Field<ListGraphType<StoreType>>(
                "stores",
                resolve: context =>
                {
                    return bikeStoreRepository.GetStores();
                });
        }
    }
}
