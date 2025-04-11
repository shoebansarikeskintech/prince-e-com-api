using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;
using ViewModel;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ShippingMethodController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ShippingMethodController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllShippingMethod")]
        public async Task<IActionResult> getAllShippingMethod()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} SpGetAllShippingMethod");
            var getAllShippingMethod = await _serviceManager.shippingMethodContract.getAllShippingMethod();
            if (getAllShippingMethod.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Shipping Method List");
            }
            return Ok(getAllShippingMethod);
        }

        [HttpPost("addShippingMethod")]
        [Authorize]
        public async Task<IActionResult> addShippingMethod(AddShippingMethodViewModel addShippingMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addShippingMethod");
            var add = await _serviceManager.shippingMethodContract.addShippingMethod(addShippingMethod);
            return Ok(add);
        }

        [HttpPost("updateShippingMethod")]
        [Authorize]
        public async Task<IActionResult> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} updateShippingMethod");
            var add = await _serviceManager.shippingMethodContract.updateShippingMethod(updateShippingMethod);
            return Ok(add);
        }

        [HttpPost("deleteShippingMethod")]
        [Authorize]
        public async Task<IActionResult> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} deleteShippingMethod");
            var delete = await _serviceManager.shippingMethodContract.deleteShippingMethod(deleteShippingMethod);
            return Ok(delete);
        }
    }
}
