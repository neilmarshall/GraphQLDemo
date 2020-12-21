using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQLDemo.Interfaces.Models.Production;
using GraphQLDemo.Interfaces.Models.Sales;
using GraphQLDemo.Interfaces.Repository;
using GraphQLDemo.DAL.ADO.Net.Wrappers;

namespace GraphQLDemo.DAL
{
    public class BikeStoreRepository : IBikeStoreRepository
    {
        private readonly ADOHelper _adoHelper;
        private readonly Mapper _mapper;

        public BikeStoreRepository(string connectionString)
        {
            this._adoHelper = new ADOHelper(connectionString);

            this._mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOs.Production.Brand, Brand>();
                cfg.CreateMap<DTOs.Production.Category, Category>();
                cfg.CreateMap<DTOs.Production.Product, Product>();
                cfg.CreateMap<DTOs.Production.Stock, Stock>();
                cfg.CreateMap<DTOs.Sales.Customer, Customer>();
                cfg.CreateMap<DTOs.Sales.Order, Order>();
                cfg.CreateMap<DTOs.Sales.OrderItem, OrderItem>();
                cfg.CreateMap<DTOs.Sales.Staff, Staff>();
                cfg.CreateMap<DTOs.Sales.Store, Store>();
            }));
        }

        public async Task<Brand> GetBrand(int brandId)
        {
            var query = "SELECT * FROM [production].[brands] WHERE [brand_id] = @brandId;";
            var parameters = new Dictionary<string, object>{ { "brandId", brandId } };
            var brands = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Production.Brand>(query, parameters));
            return brands.Select(brand => this._mapper.Map<Brand>(brand)).FirstOrDefault();
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            var query = "SELECT * FROM [production].[brands];";
            var brands = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Production.Brand>(query));
            return brands.Select(brand => this._mapper.Map<Brand>(brand));
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var query = "SELECT * FROM [production].[categories];";
            var categories = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Production.Category>(query));
            return categories.Select(category => this._mapper.Map<Category>(category));
        }

        public async Task<IEnumerable<Customer>> GetCustomers(int page, int itemsPerPage)
        {
            var query = "SELECT * FROM [sales].[customers] ORDER BY customer_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            var parameters = new Dictionary<string, object>
            {
                { "offset", (page - 1) * itemsPerPage },
                { "rows", itemsPerPage }
            };
            var customers = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Sales.Customer>(query, parameters));
            return customers.Select(customer => this._mapper.Map<Customer>(customer));
        }

        public async Task<IEnumerable<Order>> GetOrders(int page, int itemsPerPage)
        {
            var query = "SELECT * FROM [sales].[orders] ORDER BY order_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            var parameters = new Dictionary<string, object>
            {
                { "offset", (page - 1) * itemsPerPage },
                { "rows", itemsPerPage }
            };
            var orders = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Sales.Order>(query, parameters));
            return orders.Select(order => this._mapper.Map<Order>(order));
        }

        public async Task<IEnumerable<OrderItem>> GetOrdersItems(int page, int itemsPerPage)
        {
            var query = "SELECT * FROM [sales].[order_items] ORDER BY order_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            var parameters = new Dictionary<string, object>
            {
                { "offset", (page - 1) * itemsPerPage },
                { "rows", itemsPerPage }
            };
            var orderItems = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Sales.OrderItem>(query, parameters));
            return orderItems.Select(orderItem => this._mapper.Map<OrderItem>(orderItem));
        }

        public async Task<IEnumerable<Product>> GetProducts(int page, int itemsPerPage)
        {
            var query = "SELECT * FROM [production].[products] ORDER BY product_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            var parameters = new Dictionary<string, object>
            {
                { "offset", (page - 1) * itemsPerPage },
                { "rows", itemsPerPage }
            };
            var products = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Production.Product>(query, parameters));
            return products.Select(product => this._mapper.Map<Product>(product));
        }

        public async Task<IEnumerable<Staff>> GetStaff()
        {
            var query = "SELECT * FROM [sales].[staffs];";
            var staff = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Sales.Staff>(query));
            return staff.Select(_staff => this._mapper.Map<Staff>(_staff));
        }

        public async Task<IEnumerable<Stock>> GetStocks(int page, int itemsPerPage)
        {
            var query = "SELECT * FROM [production].[stocks] ORDER BY store_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            var parameters = new Dictionary<string, object>
            {
                { "offset", (page - 1) * itemsPerPage },
                { "rows", itemsPerPage }
            };
            var stocks = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Production.Stock>(query, parameters));
            return stocks.Select(stock => this._mapper.Map<Stock>(stock));
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            var query = "SELECT * FROM [sales].[stores];";
            var stores = await Task.Run(() => this._adoHelper.GetRecords<DTOs.Sales.Store>(query));
            return stores.Select(store => this._mapper.Map<Store>(store));
        }
    }
}
