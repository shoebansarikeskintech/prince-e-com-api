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
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ProductController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getByIdProduct/{productId}")]
        [Authorize]
        public async Task<IActionResult> getByIdProduct(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdProduct productId ${productId}");
            var getByIdProduct = await _serviceManager.productContract.getByIdProduct(productId);
            if (getByIdProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getByIdProduct);
        }

        [HttpGet("getAllProduct")]
        [Authorize]
        public async Task<IActionResult> getAllProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProduct");
            var getAllProduct = await _serviceManager.productContract.getAllProduct();
            if (getAllProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllProduct);
        }

        [HttpGet("getAllProductForUser")]
        public async Task<IActionResult> getAllProductForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProductForUser");
            var getAllProductForUser = await _serviceManager.productContract.getAllProductForUser();
            if (getAllProductForUser.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllProductForUser);
        }

        [HttpGet("getAllProductDetails")]
        public async Task<IActionResult> getAllProductDetails(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProductDetails");
            var getAllProductDetails = await _serviceManager.productContract.getAllProductDetails(productId);
            if (getAllProductDetails.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Details Found");
            }
            return Ok(getAllProductDetails);
        }

        [HttpPost("addProduct")]
        [Authorize]
        public async Task<IActionResult> addProduct(AddProductViewModel addProduct)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addProduct");
            var add = await _serviceManager.productContract.addProduct(addProduct);
            return Ok(add);
        }

        [HttpPost("updateProduct")]
        [Authorize]
        public async Task<IActionResult> updateProduct(UpdateProductViewModel updateProduct)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateProductImage");
            var update = await _serviceManager.productContract.updateProduct(updateProduct);
            return Ok(update);
        }

        [HttpPost("deleteProduct")]
        [Authorize]
        public async Task<IActionResult> deleteCategory(DeleteProductViewModel deleteProduct)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteProduct");
            var delete = await _serviceManager.productContract.deleteProduct(deleteProduct);
            return Ok(delete);
        }


        [HttpGet("getByIdProductImage/{productImageId}")]
        [Authorize]
        public async Task<IActionResult> getByIdProductImage(Guid productImageId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdProductImage productImageId ${productImageId}");
            var getByIdProductImage = await _serviceManager.productContract.getByIdProductImage(productImageId);
            if (getByIdProductImage.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Image Found");
            }
            return Ok(getByIdProductImage);
        }

        [HttpGet("getAllProductImage")]
        [Authorize]
        public async Task<IActionResult> getAllProductImage(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProductImage");
            var getAllProductImage = await _serviceManager.productContract.getAllProductImage(productId);
            if (getAllProductImage.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Image Found");
            }
            return Ok(getAllProductImage);
        }

        [HttpGet("getAllProductImageForUser")]
        public async Task<IActionResult> getAllProductImageForUser(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProductImageForUser");
            var getAllProductImageForUser = await _serviceManager.productContract.getAllProductImageForUser(productId);
            if (getAllProductImageForUser.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Image Found");
            }
            return Ok(getAllProductImageForUser);
        }

        [HttpPost("addProductImage")]
        [Authorize]
        public async Task<IActionResult> addProductImage(AddProductImageViewModel addProductImage)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addProductImage");
            var add = await _serviceManager.productContract.addProductImage(addProductImage);
            return Ok(add);
        }

        [HttpPost("updateProductImage")]
        [Authorize]
        public async Task<IActionResult> updateProductImage(UpdateProductImageViewModel updateProductImage)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateProductImage");
            var update = await _serviceManager.productContract.updateProductImage(updateProductImage);
            return Ok(update);
        }

        [HttpPost("deleteProductImage")]
        [Authorize]
        public async Task<IActionResult> deleteCategory(DeleteProductImageViewModel deleteProductImage)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteProductImage");
            var delete = await _serviceManager.productContract.deleteProductImage(deleteProductImage);
            return Ok(delete);
        }

        [HttpGet("getByIdImage")]
        [Authorize]
        public async Task<IActionResult> getByIdImage(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getByIdImage");
            var getByIdImage = await _serviceManager.productContract.getByIdImage(productId);
            if (getByIdImage.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Image Found");
            }
            return Ok(getByIdImage);
        }

    }
}
