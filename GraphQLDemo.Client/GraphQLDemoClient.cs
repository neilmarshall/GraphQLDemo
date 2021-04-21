using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQLDemo.Interfaces.Models.Production;

namespace GraphQLDemo.Client
{
    public class GraphQLDemoClient
    {
        private class GraphQLResponse
        {
            public Production Production { get; set; }
        }

        private class Production
        {
            public Brand[] Brands { get; set; }
        }

        private GraphQLHttpClient _client;

        public GraphQLDemoClient(string url)
        {
            _client = new GraphQLHttpClient(url, new SystemTextJsonSerializer());
        }

        public async Task<Brand[]> GetBrands()
        {
            var request = new GraphQLRequest
            {
                Query = @"query { production { brands { id brandName } } }"
            };

            var response = await _client.SendQueryAsync<GraphQLResponse>(request);

            return response.Data.Production.Brands;
        }

        public async Task<Brand> GetBrand(int brandId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query ($brandId: Int) { production { brands (brandId: $brandId) { id brandName } } }",
                Variables = new { brandId = $"{brandId}" }
            };

            var brands = await _client.SendQueryAsync<GraphQLResponse>(request);

            return brands.Data.Production.Brands.FirstOrDefault();
        }
    }
}
