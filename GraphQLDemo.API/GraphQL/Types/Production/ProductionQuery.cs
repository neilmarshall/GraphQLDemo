using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Interfaces.Repository;

namespace GraphQLDemo.API.GraphQLModel.Types.Production
{
    public class ProductionQuery : ObjectGraphType
    {
        public ProductionQuery(IBikeStoreRepository bikeStoreRepository)
        {
            Field<ListGraphType<BrandType>>(
                "brands",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "brandId" }),
                resolve: context =>
                {
                    var brandId = context.GetArgument<int?>("brandId");

                    if (brandId.HasValue)
                        return Task.WhenAll(bikeStoreRepository.GetBrand(brandId.Value));
                    return bikeStoreRepository.GetBrands();
                });

            Field<ListGraphType<ProductType>>(
                "products",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "page" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "itemsPerPage" }),
                resolve: context =>
                {
                    var page = context.GetArgument<int>("page");
                    var itemsPerPage = context.GetArgument<int>("itemsPerPage");
                    return bikeStoreRepository.GetProducts(page, itemsPerPage);
                });
        }
    }
}
