using System;
using System.Collections.Generic;
using System.Linq;
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
            var brands = await _bikeStoreRepository.GetBrands();
            return Ok(brands);
        }

        /// <summary>
        /// Return product category details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), Status200OK)]
        public async Task<IActionResult> Categories()
        {
            var categories = await _bikeStoreRepository.GetCategories();
            return Ok(categories);
        }

        /// <summary>
        /// Return product details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), Status200OK)]
        public async Task<IActionResult> Products()
        {
            var products = await _bikeStoreRepository.GetProducts();
            return Ok(products);
        }

        /// <summary>
        /// Return stock details
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Stock>), Status200OK)]
        public async Task<IActionResult> Stocks()
        {
            var stocks = await _bikeStoreRepository.GetStocks();
            return Ok(stocks);
        }
    }
}
