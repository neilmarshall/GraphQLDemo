using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQLDemo.Interfaces.Models.Production;

namespace GraphQLDemo.Client
{
    public class GraphQLDemoClient
    {
        private GraphQLHttpClient _client;

        public GraphQLDemoClient(string url)
        {
            this._client = new GraphQLHttpClient(url, new SystemTextJsonSerializer());
        }

        public async Task<Brand[]> GetBrands()
        {
            var request = new GraphQLRequest
            {
                Query = @"query {brands {id brandName}}"
            };

            var brands = await this._client.SendQueryAsync(request, () => new { Brands = Array.Empty<Brand>() });

            return brands.Data.Brands;
        }

        public async Task<Brand> GetBrand(int brandId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query($brandId: Int!) {brand(brandId: $brandId) {brandName}}",
                Variables = new { brandId = $"{brandId}" }
            };

            var brand = await this._client.SendQueryAsync(request, () => new { Brand = new Brand() });

            return brand.Data.Brand;
        }
    }
}
