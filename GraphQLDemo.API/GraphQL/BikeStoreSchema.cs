using GraphQL.Types;

namespace GraphQLDemo.API.GraphQLModel
{
    public class BikeStoreSchema : Schema
    {
        public BikeStoreSchema(BikeStoreQuery bikeStoreQuery)
        {
            Query = bikeStoreQuery;
        }
    }
}
