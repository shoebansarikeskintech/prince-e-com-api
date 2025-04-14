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
    public class CartController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public CartController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getCartItemCount/{userId}")]
      
        public async Task<IActionResult> getCartItemCount(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getCartItemCount userId ${userId}");
            var getCartItemCount = await _serviceManager.cartContract.getCartItemCount(userId);
            if (getCartItemCount.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Cart Found");
            }
            return Ok(getCartItemCount);
        }

        [HttpGet("getCartList/{userId}")]
        public async Task<IActionResult> getCartList(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getCartList");
            var getCartList = await _serviceManager.cartContract.getCartList(userId);
            if (getCartList.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Cart Found");
            }
            return Ok(getCartList);
        }


        [HttpPost("addProductInCart")]
        public async Task<IActionResult> addProductInCart(AddProductInCartViewModel addProductInCartView)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addProductInCart");

            // First, try adding the product to the cart
            var addedProduct = await _serviceManager.cartContract.addProductInCart(addProductInCartView);

            // Check if the response indicates the product is already added
            if (addedProduct != null && addedProduct.statusCode == 417) // 417: Already product added in cart
            {
                var response = new ResponseViewModel
                {
                    statusCode = 417,
                    message = "Product already added in cart.",
                    data = null
                };
                return Ok(response); // Return a response indicating the product is already in the cart
            }

            // If the product was added successfully, return the updated cart list
            if (addedProduct != null)
            {
                var userId = addProductInCartView.userId;
                var updatedCartList = await _serviceManager.cartContract.getCartList(userId);

                var response = new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.OK,
                    message = "Product added to cart.",
                    data = updatedCartList.data
                };

                return Ok(response);
            }
            else
            {
                var response = new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "Failed to add product to cart.",
                    data = null
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpPost("updateQuantityInCart")]
        public async Task<IActionResult> updateQuantityInCart(UpdateQuantityInCartViewModel updateQuantityInCart)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateQuantityInCart");
            var update = await _serviceManager.cartContract.updateQuantityInCart(updateQuantityInCart);
            return Ok(update);
        }

        [HttpPost("productRemoveInCart")]
        public async Task<IActionResult> productRemoveInCart(RemoveProductInCartViewModel removeProductInCart)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} updateQuantityInCart");
            var delete = await _serviceManager.cartContract.productRemoveInCart(removeProductInCart);
            return Ok(delete);
        }
    }
}
