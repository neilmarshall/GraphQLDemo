using GraphQL;
using GraphQL.Types;
using GraphQLDemo.API.GraphQLModel.Types.Production;
using GraphQLDemo.API.GraphQLModel.Types.Sales;
using GraphQLDemo.Interfaces.Repository;

namespace GraphQLDemo.API.GraphQLModel
{
    public class BikeStoreQuery : ObjectGraphType
    {
        public BikeStoreQuery(IBikeStoreRepository bikeStoreRepository)
        {
            Field<BrandType>(
                "brand",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name="brandId" }),
                resolve: context =>
                {
                    var brandId = context.GetArgument<int>("brandId");
                    return bikeStoreRepository.GetBrand(brandId);
                });

            Field<ListGraphType<BrandType>>(
                "brands",
                resolve: context => bikeStoreRepository.GetBrands());

            Field<ListGraphType<ProductType>>(
                "products",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name="page" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name="itemsPerPage" }),
                resolve: context =>
                {
                    var page = context.GetArgument<int>("page");
                    var itemsPerPage = context.GetArgument<int>("itemsPerPage");
                    return bikeStoreRepository.GetProducts(page, itemsPerPage);
                });

            Field<ListGraphType<StaffType>>(
                "staff",
                resolve: cotext =>
                {
                    return bikeStoreRepository.GetStaff();
                });

            Field<ListGraphType<StoreType>>(
                "stores",
                resolve: cotext =>
                {
                    return bikeStoreRepository.GetStores();
                });
        }
    }
}
