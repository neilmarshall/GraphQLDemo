using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQLDemo.Interfaces.Repository;
using GraphQLDemo.Interfaces.Models.Sales;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GraphQLDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SalesController : ControllerBase
    {
        private readonly IBikeStoreRepository _bikeStoreRepository;
        private readonly ILogger<SalesController> _logger;

        public SalesController(IBikeStoreRepository bikeStoreRepository, ILogger<SalesController> logger)
        {
            _bikeStoreRepository = bikeStoreRepository;
            _logger = logger;
        }

        /// <summary>
        /// Return customer details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), Status200OK)]
        public async Task<IActionResult> Customers()
        {
            var customers = await _bikeStoreRepository.GetCustomers();
            return Ok(customers);
        }

        /// <summary>
        /// Return order item details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderItem>), Status200OK)]
        public async Task<IActionResult> OrderItems()
        {
            var orderItems = await _bikeStoreRepository.GetOrdersItems();
            return Ok(orderItems);
        }

        /// <summary>
        /// Return order details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), Status200OK)]
        public async Task<IActionResult> Orders()
        {
            var order = await _bikeStoreRepository.GetOrders();
            return Ok(order);
        }

        /// <summary>
        /// Return staff details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Staff>), Status200OK)]
        public async Task<IActionResult> Staff()
        {
            var staff = await _bikeStoreRepository.GetStaff();
            return Ok(staff);
        }

        /// <summary>
        /// Return store details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Store>), Status200OK)]
        public async Task<IActionResult> Stores()
        {
            var stores = await _bikeStoreRepository.GetStores();
            return Ok(stores);
        }
    }
}
