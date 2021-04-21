using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQLDemo.Interfaces.Models.Production;
using GraphQLDemo.Interfaces.Models.Sales;
using GraphQLDemo.Interfaces.Repository;
using System.Data.SqlClient;
using Dapper;

namespace GraphQLDemo.DAL
{
    public class BikeStoreRepository : IBikeStoreRepository
    {
        private readonly string _connectionString;
        private readonly Mapper _mapper;

        public BikeStoreRepository(string connectionString)
        {
            _connectionString = connectionString;

            _mapper = new Mapper(new MapperConfiguration(cfg =>
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
            var query = "SELECT brand_id id, brand_name brandName FROM [production].[brands] WHERE [brand_id] = @brandId;";
            using var connection = new SqlConnection(_connectionString);
            var brand = (await connection.QueryFirstOrDefaultAsync<DTOs.Production.Brand>(query, new { brandId }));
            return _mapper.Map<Brand>(brand);
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            var query = "SELECT brand_id id, brand_name brandName FROM [production].[brands];";
            using var connection = new SqlConnection(_connectionString);
            var brands = (await connection.QueryAsync<DTOs.Production.Brand>(query)).ToList();
            return brands.Select(brand => _mapper.Map<Brand>(brand));
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var query = "SELECT category_id id, category_name categoryName FROM [production].[categories];";
            using var connection = new SqlConnection(_connectionString);
            var categories = (await connection.QueryAsync<DTOs.Production.Category>(query)).ToList();
            return categories.Select(category => _mapper.Map<Category>(category));
        }

        public async Task<IEnumerable<Customer>> GetCustomers(int page, int itemsPerPage)
        {
            var query = "SELECT customer_id id, first_name firstName, last_name lastName, phone, email, street, city, state, zip_code zipcode FROM [sales].[customers] ORDER BY customer_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            using var connection = new SqlConnection(_connectionString);
            var customers = (await connection.QueryAsync<DTOs.Sales.Customer>(
                query,
                new { offset = (page - 1) * itemsPerPage, rows = itemsPerPage })).ToList();
            return customers.Select(customer => _mapper.Map<Customer>(customer));
        }

        public async Task<IEnumerable<Order>> GetOrders(int page, int itemsPerPage)
        {
            var query = "SELECT order_id id, customer_id customerId, order_status orderStatus, order_date orderDate, required_date requiredDate, shipped_date shippedDate, store_id storeId, staff_id staffId FROM [sales].[orders] ORDER BY order_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            using var connection = new SqlConnection(_connectionString);
            var orders = (await connection.QueryAsync<DTOs.Sales.Order>(
                query,
                new { offset = (page - 1) * itemsPerPage, rows = itemsPerPage })).ToList();
            return orders.Select(order => _mapper.Map<Order>(order));
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(int page, int itemsPerPage)
        {
            var query = "SELECT order_id id, item_id itemId, product_id productId, quantity, list_price listPrice, discount FROM [sales].[order_items] ORDER BY order_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            using var connection = new SqlConnection(_connectionString);
            var orderItems = (await connection.QueryAsync<DTOs.Sales.OrderItem>(
                query,
                new { offset = (page - 1) * itemsPerPage, rows = itemsPerPage })).ToList();
            return orderItems.Select(orderItem => _mapper.Map<OrderItem>(orderItem));
        }

        public async Task<IEnumerable<Product>> GetProducts(int page, int itemsPerPage)
        {
            var query = "SELECT product_id id, product_name productName, brand_id brandId, category_id categoryId, model_year modelYear, list_price ListPrice FROM [production].[products] ORDER BY product_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            using var connection = new SqlConnection(_connectionString);
            var products = (await connection.QueryAsync<DTOs.Production.Product>(
                query,
                new { offset = (page - 1) * itemsPerPage , rows = itemsPerPage })).ToList();
            return products.Select(product => _mapper.Map<Product>(product));
        }

        public async Task<IEnumerable<Staff>> GetStaff()
        {
            var query = "SELECT staff_id staffId, first_name firstName, last_name lastName, email, phone, active, store_id storeId, manager_id managerId FROM [sales].[staffs];";
            using var connection = new SqlConnection(_connectionString);
            var staff = (await connection.QueryAsync<DTOs.Sales.Staff>(query)).ToList();
            return staff.Select(_staff => _mapper.Map<Staff>(_staff));
        }

        public async Task<IEnumerable<Stock>> GetStocks(int page, int itemsPerPage)
        {
            var query = "SELECT store_id storeId, product_id productId, quantity FROM [production].[stocks] ORDER BY store_id OFFSET @offset ROWS FETCH NEXT @rows ROWS ONLY;";
            using var connection = new SqlConnection(_connectionString);
            var stocks = (await connection.QueryAsync<DTOs.Production.Stock>(
                query,
                new { offset = (page - 1) * itemsPerPage, rows = itemsPerPage })).ToList();
            return stocks.Select(stock => _mapper.Map<Stock>(stock));
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            var query = "SELECT store_id id, store_name storeName, phone, email, street, city, state, zip_code zipCode FROM [sales].[stores];";
            using var connection = new SqlConnection(_connectionString);
            var stores = (await connection.QueryAsync<DTOs.Sales.Store>(query)).ToList();
            return stores.Select(store => _mapper.Map<Store>(store));
        }
    }
}
