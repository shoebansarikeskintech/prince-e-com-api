﻿using LoggerService;
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

        [HttpGet("getAllOrderlist")]
        public async Task<IActionResult> getAllOrderlist()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrderlist");
            var getAllOrder = await _serviceManager.orderContract.getAllOrderlist();
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Found");
            }
            return Ok(getAllOrder);
        }

        [HttpGet("getAllOrder")]
        public async Task<IActionResult> getAllOrder(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrder");
            var getAllOrder = await _serviceManager.orderContract.getAllOrder(userId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Found");
            }
            return Ok(getAllOrder);
        }
      
        [HttpGet("getAllPendingOrder")]
        public async Task<IActionResult> getAllPendingOrder(Guid adminUserId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllPendingOrder");
            var getAllPendingOrder = await _serviceManager.orderContract.getAllPendingOrder(adminUserId);
            if (getAllPendingOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Pending Order Found");
            }
            return Ok(getAllPendingOrder);
        }

        [HttpGet("getAllProcessingOrder")]
        public async Task<IActionResult> getAllProcessingOrder(Guid adminUserId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllProcessingOrder");
            var getAllProcessingOrder = await _serviceManager.orderContract.getAllProcessingOrder(adminUserId);
            if (getAllProcessingOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Processing Order Found");
            }
            return Ok(getAllProcessingOrder);
        }

        [HttpGet("getAllCompletedOrder")]
        public async Task<IActionResult> getAllCompletedOrder(Guid adminUserId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCompletedOrder");
            var getAllProcessingOrder = await _serviceManager.orderContract.getAllCompletedOrder(adminUserId);
            if (getAllProcessingOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Completed Order Found");
            }
            return Ok(getAllProcessingOrder);
        }

        [HttpGet("getAllCancelOrder")]
        public async Task<IActionResult> getAllCancelOrder(Guid adminUserId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCancelOrder");
            var getAllCancelOrder = await _serviceManager.orderContract.getAllCancelOrder(adminUserId);
            if (getAllCancelOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Cancel Order Found");
            }
            return Ok(getAllCancelOrder);
        }
        
        [HttpPost("addOrderWithDetails")]
        [Authorize]
        public async Task<IActionResult> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderWithDetails)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addShippingMethod");
            var add = await _serviceManager.orderContract.addOrderWithDetails(addOrderWithDetails);
            return Ok(add);
        }

        [HttpGet("getAllOrderByOrderIdOrOrderNo")]
        public async Task<IActionResult> getAllOrderByOrderIdOrOrderNo(string orderId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} SpGetAllOrderByOrderId");
            var getAllOrder = await _serviceManager.orderContract.getAllOrderByOrderId(orderId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Details Found");
            }
            return Ok(getAllOrder);
        }

        [HttpGet("getAllOrderByNameorEmail")]
        public async Task<IActionResult> getAllOrderByNameorEmail(String userNameorEmail)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrderByNameorEmail");
            var getAllOrder = await _serviceManager.orderContract.getAllOrderByNameorEmail(userNameorEmail);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Order Details Found");
            }
            return Ok(getAllOrder);
        }

        [HttpPost("updateOrderStatus")]
        [Authorize]
        public async Task<IActionResult> updateOrderStatus(UpdateStausViewModel updateStausViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} updateOrderStatus");
            var add = await _serviceManager.orderContract.updateOrderStatus(updateStausViewModel);
            return Ok(add);
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
    }
}
