using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLDemo.Interfaces.Models.Production;
using GraphQLDemo.Interfaces.Models.Sales;

namespace GraphQLDemo.Interfaces.Repository
{
    public interface IBikeStoreRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<OrderItem>> GetOrdersItems();
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Staff>> GetStaff();
        Task<IEnumerable<Stock>> GetStocks();
        Task<IEnumerable<Store>> GetStores();
    }
}

