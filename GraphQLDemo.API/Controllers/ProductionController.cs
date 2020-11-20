using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQLDemo.Interfaces.Repository;
using GraphQLDemo.Interfaces.Models.Production;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace GraphQLDemo.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductionController : ControllerBase
    {
        private readonly IBikeStoreRepository _bikeStoreRepository;
        private readonly ILogger<ProductionController> _logger;

        public ProductionController(IBikeStoreRepository bikeStoreRepository, ILogger<ProductionController> logger)
        {
            _bikeStoreRepository = bikeStoreRepository;
            _logger = logger;
        }

        /// <summary>
        /// Return brand details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Brand>), Status200OK)]
        public async Task<IActionResult> Brands()
        {
            try
            {
                var brands = await _bikeStoreRepository.GetBrands();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return product category details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), Status200OK)]
        public async Task<IActionResult> Categories()
        {
            try
            {
                var categories = await _bikeStoreRepository.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return product details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Products(int page, int itemsPerPage)
        {
            if (page <= 0 || itemsPerPage <= 0)
                return BadRequest();

            try
            {
                var products = await _bikeStoreRepository.GetProducts(page, itemsPerPage);
                return Ok(products);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }

        /// <summary>
        /// Return stock details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Stock>), Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<IActionResult> Stocks(int page, int itemsPerPage)
        {
            if (page <= 0 || itemsPerPage <= 0)
                return BadRequest();

            try
            {
                var stocks = await _bikeStoreRepository.GetStocks(page, itemsPerPage);
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return new StatusCodeResult(Status500InternalServerError);
            }
        }
    }
}
