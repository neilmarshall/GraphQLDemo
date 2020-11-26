using System;
using GraphQL.Types;

namespace GraphQLDemo.API.GraphQLModel
{
    public class BikeStoreSchema : Schema
    {
        public BikeStoreSchema(IServiceProvider serviceProvider, BikeStoreQuery bikeStoreQuery)
            : base(serviceProvider)
        {
            Query = bikeStoreQuery;
        }
    }
}
