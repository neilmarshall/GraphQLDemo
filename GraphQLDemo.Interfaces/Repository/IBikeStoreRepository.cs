using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLDemo.Interfaces.Models.Production;
using GraphQLDemo.Interfaces.Models.Sales;

namespace GraphQLDemo.Interfaces.Repository
{
    public interface IBikeStoreRepository
    {
        Task<Brand> GetBrand(int brandId);
        Task<IEnumerable<Brand>> GetBrands();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Customer>> GetCustomers(int page, int itemsPerPage);
        Task<IEnumerable<Order>> GetOrders(int page, int itemsPerPage);
        Task<IEnumerable<OrderItem>> GetOrdersItems(int page, int itemsPerPage);
        Task<IEnumerable<Product>> GetProducts(int page, int itemsPerPage);
        Task<IEnumerable<Staff>> GetStaff();
        Task<IEnumerable<Stock>> GetStocks(int page, int itemsPerPage);
        Task<IEnumerable<Store>> GetStores();
    }
}

