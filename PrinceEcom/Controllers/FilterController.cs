using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;
using ViewModel;

namespace PrinceEcom.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public FilterController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllSortBy")]
        public async Task<IActionResult> getAllSortBy()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSortBy");
            var getAllSortBy = await _serviceManager.filterContract.getAllSortBy();
            if (getAllSortBy.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllSortBy);
        }

        [HttpGet("getAllFilter")]
        public async Task<IActionResult> getAllFilter()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllFilter");
            var getAllFilter = await _serviceManager.filterContract.getAllFilter();
            if (getAllFilter.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllFilter);
        }

        [HttpPost("getProductSearchByFilterNew")]
        public async Task<IActionResult> getProductSearchByFilterNew([FromBody] FilterViewModel model)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getPrductSearchByFilter");
            var getProductSearchByFilter = await _serviceManager.filterContract.getProductSearchByFilter(model);
            if (getProductSearchByFilter.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getProductSearchByFilter);
        }

        [HttpPost("getProductSearchByFilter")]
        public async Task<IActionResult> getProductSearchByFilter([FromBody] FilterViewModelNew model)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getPrductSearchByFilter");
            var getProductSearchByFilter = await _serviceManager.filterContract.getProductSearchByFilterNew(model);
            if (getProductSearchByFilter.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getProductSearchByFilter);
        }

        [HttpGet("getAllSkinInsightProduct")]
        public async Task<IActionResult> getAllSkinInsightProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSkinInsightProduct");
            var getAllSortBy = await _serviceManager.filterContract.getAllSkinInsightProduct();
            if (getAllSortBy.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllSortBy);
        }

   
        [HttpPost("addSkinInsightProduct")]
        public async Task<IActionResult> addSkinInsightProduct(AddSkinInsightProductViewModel addSkinInsightProduct)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addSkinInsightProduct");
            var add = await _serviceManager.filterContract.addSkinInsightProduct(addSkinInsightProduct);
            return Ok(add);
        }

        [HttpPost("updateSkinInsightProduct")]
        public async Task<IActionResult> updateSkinInsightProduct(UpdateSkinInsightProductViewModel updateSkinInsightProduct)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateSkinInsightProduct");
            var update = await _serviceManager.filterContract.updateSkinInsightProduct(updateSkinInsightProduct);
            return Ok(update);
        }

        [HttpPost("deleteSkinInsightProduct")]
        public async Task<IActionResult> deleteSkinInsightProduct(DeleteSkinInsightProductViewModel deleteSkinInsightProduct)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteShipping");
            var delete = await _serviceManager.filterContract.deleteSkinInsightProduct(deleteSkinInsightProduct);
            return Ok(delete);
        }


        [HttpGet("getAllSimilarProduct")]
        public async Task<IActionResult> getAllSimilarProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSimilarProduct");
            var getAllSimilarProduct = await _serviceManager.filterContract.getAllSimilarProduct();
            if (getAllSimilarProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllSimilarProduct);
        }


        [HttpGet("getAllSimilarProductByProductId")]
        public async Task<IActionResult> getAllSimilarProductByProductId(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSimilarProductByProductId");
            var getAllSortBy = await _serviceManager.filterContract.getAllSimilarProductByProductId(productId);
            if (getAllSortBy.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllSortBy);
        }

        [HttpPost("addSimilarProduct")]
        public async Task<IActionResult> addSimilarProduct(AddSimilarProductViewModel addSimilarProduct)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addSimilarProduct");
            var add = await _serviceManager.filterContract.addSimilarProduct(addSimilarProduct);
            return Ok(add);
        }

        [HttpPost("updateSimilarProduct")]
        public async Task<IActionResult> updateSimilarProduct(UpdateSimilarProductViewModel updateSimilarProduct)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateSimilarProduct");
            var update = await _serviceManager.filterContract.updateSimilarProduct(updateSimilarProduct);
            return Ok(update);
        }

        [HttpPost("deleteSimilarProduct")]
        public async Task<IActionResult> deleteSimilarProduct(DeleteSimilarProductViewModel deleteSimilarProduct)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteSimilarProduct");
            var delete = await _serviceManager.filterContract.deleteSimilarProduct(deleteSimilarProduct);
            return Ok(delete);
        }

        [HttpPost("SearchAllSkinInsightProduct")]
        public async Task<IActionResult> SearchAllSkinInsightProduct(SearchSkinInsightProductViewModelNew searchSkinInsightProduct)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} SearchAllSkinInsightProduct");
            var delete = await _serviceManager.filterContract.SearchAllSkinInsightProduct(searchSkinInsightProduct);
            return Ok(delete);
        }

        [HttpGet("getAllSkinInsightProductbyProductId")]
        public async Task<IActionResult> getAllSkinInsightProductbyProductId(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSkinInsightProductProductId");
            var getAllSortBy = await _serviceManager.filterContract.getAllSkinInsightProductProductId(productId);
            if (getAllSortBy.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllSortBy);
        }
    }
}
