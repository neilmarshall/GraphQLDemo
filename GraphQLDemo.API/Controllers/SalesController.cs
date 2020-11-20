using System;
using System.Collections.Generic;
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
            try
            {
                var customers = await _bikeStoreRepository.GetCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return order item details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderItem>), Status200OK)]
        public async Task<IActionResult> OrderItems()
        {
            try
            {
                var orderItems = await _bikeStoreRepository.GetOrdersItems();
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return order details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), Status200OK)]
        public async Task<IActionResult> Orders()
        {
            try
            {
                var order = await _bikeStoreRepository.GetOrders();
                return Ok(order);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return staff details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Staff>), Status200OK)]
        public async Task<IActionResult> Staff()
        {
            try
            {
                var staff = await _bikeStoreRepository.GetStaff();
                return Ok(staff);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return store details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Store>), Status200OK)]
        public async Task<IActionResult> Stores()
        {
            try
            {
                var stores = await _bikeStoreRepository.GetStores();
                return Ok(stores);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }
    }
}
