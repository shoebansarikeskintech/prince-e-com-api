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

        [HttpGet("getIsBestSellerProduct")]
        [Authorize]
        public async Task<IActionResult> getIsBestSellerProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProduct");
            var getAllProduct = await _serviceManager.productContract.getBestSeller();
            if (getAllProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllProduct);
        }


        [HttpGet("getAllIsRecommendedProduct")]
        [Authorize]
        public async Task<IActionResult> getAllIsRecommendedProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProduct");
            var getAllProduct = await _serviceManager.productContract.getIsRecommended();
            if (getAllProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllProduct);
        }

        [HttpGet("getAllIsNewArrialProduct")]
        [Authorize]
        public async Task<IActionResult> getAllIsNewArrialProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllIsNewArrialProduct");
            var getAllProduct = await _serviceManager.productContract.getIsNewArrial();
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
        public async Task<IActionResult> getAllProductDetails(Int32 id)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProductDetails");
            var getAllProductDetails = await _serviceManager.productContract.getAllProductDetails(id);
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

        [HttpGet("getAllSteps")]
        public async Task<IActionResult> getAllSteps()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSteps");
            var getAllSteps = await _serviceManager.productContract.getAllSteps();
            if (getAllSteps.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllSteps);
        }

        [HttpGet("getAllActiveSteps")]
        public async Task<IActionResult> getAllActiveSteps()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllActiveSteps");
            var getAllActiveSteps = await _serviceManager.productContract.getAllActiveSteps();
            if (getAllActiveSteps.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllActiveSteps);
        }

        [HttpPost("addAllSteps")]
        [Authorize]
        public async Task<IActionResult> addAllSteps(AddStepsViewModel addSteps)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addAllSteps");
            var add = await _serviceManager.productContract.addAllSteps(addSteps);
            return Ok(add);
        }

        [HttpPost("updateAllSteps")]
        [Authorize]
        public async Task<IActionResult> updateAllSteps(UpdateStepsViewModel updateSteps)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateSteps");
            var update = await _serviceManager.productContract.updateAllSteps(updateSteps);
            return Ok(update);
        }

        [HttpPost("deleteAllSteps")]
        [Authorize]
        public async Task<IActionResult> deleteAllSteps(DeleteStepsViewModel deleteSteps)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteProduct");
            var delete = await _serviceManager.productContract.deleteAllSteps(deleteSteps);
            return Ok(delete);
        }

        [HttpGet("getAllTypeofProduct")]
        public async Task<IActionResult> getAllTypeofProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllTypeofProduct");
            var getAllTypeofProduct = await _serviceManager.productContract.getAllTypeofProduct();
            if (getAllTypeofProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllTypeofProduct);
        }

        [HttpGet("getAllTypeofActiveProduct")]
        public async Task<IActionResult> getAllTypeofActiveProduct()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllTypeofActiveProduct");
            var getAllTypeofProduct = await _serviceManager.productContract.getAllTypeofActiveProduct();
            if (getAllTypeofProduct.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(getAllTypeofProduct);
        }

        [HttpPost("addTypeOfProduct")]
        [Authorize]
        public async Task<IActionResult> addTypeOfProduct(AddTypeOfProductViewModel addTypeOfProduct)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addTypeOfProduct");
            var add = await _serviceManager.productContract.addTypeOfProduct(addTypeOfProduct);
            return Ok(add);
        }

        [HttpPost("updateTypeOfProduct")]
        [Authorize]
        public async Task<IActionResult> updateTypeOfProduct(UpdateTypeOfProductViewModel updateTypeOfProduct)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateTypeOfProduct");
            var update = await _serviceManager.productContract.updateTypeOfProduct(updateTypeOfProduct);
            return Ok(update);
        }

        [HttpPost("deleteTypeOfProduct")]
        [Authorize]
        public async Task<IActionResult> deleteTypeOfProduct(DeleteSTypeOfProductMdoel deleteSTypeOfProduct)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteTypeOfProduct");
            var delete = await _serviceManager.productContract.deleteTypeOfProduct(deleteSTypeOfProduct);
            return Ok(delete);
        }
        [HttpPost("searchProduct")]
        public async Task<IActionResult> searchProduct(SearchCommonDataViewModel searchCommonData)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} searchProduct");
            var search = await _serviceManager.productContract.searchProduct(searchCommonData);
            return Ok(search);
        }

        [HttpGet("searchProductNew/{commonTypeSearch}")]     
        public async Task<IActionResult> searchProductNew(string commonTypeSearch)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdProduct productId ${commonTypeSearch}");
            var searchProductNew = await _serviceManager.productContract.searchProductNew(commonTypeSearch);
            if (searchProductNew.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Product Found");
            }
            return Ok(searchProductNew);
        }
    }
}
