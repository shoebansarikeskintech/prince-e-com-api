using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PrinceEcom.Utils;
using ServiceContract;
using System.Data;
using System.Net;
using ViewModel;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public OrderController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

       

        [HttpGet("getAllOrderByUserId")]
        public async Task<IActionResult> getAllOrderByUserId(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrder");
            var getAllOrder = await _serviceManager.orderContract.getAllOrder(userId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Found");
            }
            return Ok(getAllOrder);
        }

        [HttpPost("updateOrderStatusUser")]
        [Authorize]
        public async Task<IActionResult> updateOrderStatusUser(UpdateStausViewModel updateStausViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} updateOrderStatus");
            var add = await _serviceManager.orderContract.updateOrderStatus(updateStausViewModel);
            return Ok(add);
        }


        [HttpPost("addOrderWithDetails")]
        [Authorize]
        public async Task<IActionResult> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderWithDetails)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addShippingMethod");
            var add = await _serviceManager.orderContract.addOrderWithDetails(addOrderWithDetails);
            return Ok(add);
        }

        [HttpGet("getOrdersBySearchAdmin")]
        public async Task<IActionResult> getOrdersBySearchAdmin(string searchValue)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrder");
            var getAllOrder = await _serviceManager.orderContract.getOrdersBySearch(searchValue);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Found");
            }
            return Ok(getAllOrder);
        }

               
        [HttpGet("OrderWithItems")]
        public async Task<IActionResult> OrderWithItems(string orderId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getOrderWithItems");
            var getAllOrder = await _serviceManager.orderContract.getOrderWithItems(orderId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Found");
            }
            return Ok(getAllOrder);
        }

        //update st
        [HttpPost("updateOrderStatusAdmin")]
        [Authorize]
        public async Task<IActionResult> updateOrderStatusAdmin(UpdateStausViewModel updateStausViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} updateOrderStatus");
            var add = await _serviceManager.orderContract.updateOrderStatus(updateStausViewModel);
            return Ok(add);
        }

        //yaha user ke sare order ayenge
        [HttpGet("getAllOrderListAdmin")]
        public async Task<IActionResult> getAllOrderListAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrderlist");
            var getAllOrder = await _serviceManager.orderContract.getAllOrderlist();
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Found");
            }
            return Ok(getAllOrder);
        }

        //order shipped pack ho raha h
        //pending me order shipped aa raha hai 
        [HttpGet("getSuccessfullOrderAdmin")]
        public async Task<IActionResult> getAllSuccessfullOrderAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllPendingOrder");
            var getAllPendingOrder = await _serviceManager.orderContract.getAllPendingOrder();
            if (getAllPendingOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Pending Order Found");
            }
            return Ok(getAllPendingOrder);
        }

        //delivery seuccessfully poch gaya 
        [HttpGet("getAllCompletedOrderAdmin")]
        public async Task<IActionResult> getAllCompletedOrderAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCompletedOrder");
            var getAllProcessingOrder = await _serviceManager.orderContract.getAllCompletedOrder();
            if (getAllProcessingOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Completed Order Found");
            }
            return Ok(getAllProcessingOrder);
        }
             
        //order shipped ho gaya hai 
        [HttpGet("getAllShippingOrderlistAdmin")]
        public async Task<IActionResult> getAllShippingOrderlistAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllShippingOrderlist");
            var getAllCancelOrder = await _serviceManager.orderContract.getAllShippingOrderlist();
            if (getAllCancelOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Cancel Order Found");
            }
            return Ok(getAllCancelOrder);
        }


        //order cancel ho gaya hai 
        [HttpGet("CancelOrderlistAdmin")]
        public async Task<IActionResult> cancelOrderlistAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCancelOrder");
            var getAllCancelOrder = await _serviceManager.orderContract.getAllCancelOrder();
            if (getAllCancelOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Cancel Order Found");
            }
            return Ok(getAllCancelOrder);
        }

        //order return ho gaya hai 
        [HttpGet("returnOrderlistAdmin")]
        public async Task<IActionResult> returnOrderlistAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllReturnOrderlist");
            var getAllCancelOrder = await _serviceManager.orderContract.getAllReturnOrderlist();
            if (getAllCancelOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Cancel Order Found");
            }
            return Ok(getAllCancelOrder);
        }

        //order return ho gaya hai 
        [HttpGet("returnOrderAcceptedAdmin")]
        public async Task<IActionResult> returnOrderAcceptedAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllReturnOrderAccepted");
            var getAllCancelOrder = await _serviceManager.orderContract.getAllReturnOrderAccepted();
            if (getAllCancelOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Cancel Order Found");
            }
            return Ok(getAllCancelOrder);
        }

        //return order completed ho gaya 
        [HttpGet("returnOrderCompletedAdmin")]
        public async Task<IActionResult> returnOrderCompletedAdmin()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllReturnOrderCompleted");
            var getAllCancelOrder = await _serviceManager.orderContract.getAllReturnOrderCompleted();
            if (getAllCancelOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All return Order Found");
            }
            return Ok(getAllCancelOrder);
        }
    }
}
