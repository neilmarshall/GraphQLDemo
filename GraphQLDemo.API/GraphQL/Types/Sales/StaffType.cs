using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDemo.Interfaces.Models.Sales;
using GraphQLDemo.Interfaces.Repository;

namespace GraphQLDemo.API.GraphQLModel.Types.Sales
{
    public class StaffType : ObjectGraphType<Staff>
    {
        public StaffType(IDataLoaderContextAccessor accessor, IBikeStoreRepository bikeStoreRepository)
        {
            Field(t => t.Active);
            Field(t => t.Email);
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field(t => t.ManagerId, nullable: true);
            Field(t => t.Phone);
            Field(t => t.StaffId);
            Field<StoreType, Store>()
                .Name("store")
                .ResolveAsync(context =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, Store>(
                        "StoreTypeLoader",
                        async storeIds =>
                        {
                            var stores = await bikeStoreRepository.GetStores();
                            return stores.ToDictionary(s => s.Id, s => s);
                        });

                    return loader.LoadAsync(context.Source.StoreId);
                });
        }
    }
}
