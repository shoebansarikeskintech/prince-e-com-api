using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShippingController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ShippingController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getByIdShipping/{shippingId}")]
        public async Task<IActionResult> getByIdShipping(Guid shippingId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdShipping shippingId ${shippingId}");
            var getByIdShipping = await _serviceManager.shippingContract.getByIdShipping(shippingId);
            if (getByIdShipping.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Shipping Found");
            }
            return Ok(getByIdShipping);
        }

        [HttpGet("getAllShipping")]
        public async Task<IActionResult> getAllShipping()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllShipping");
            var getAllShipping = await _serviceManager.shippingContract.getAllShipping();
            if (getAllShipping.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Shipping Found");
            }
            return Ok(getAllShipping);
        }

        [HttpPost("addShipping")]
        public async Task<IActionResult> addShipping(AddShippingViewModel addShipping)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addShipping");
            var add = await _serviceManager.shippingContract.addShipping(addShipping);
            return Ok(add);
        }

        [HttpPost("updateShipping")]
        public async Task<IActionResult> updateShipping(UpdateShippingViewModel updateShipping)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateShipping");
            var update = await _serviceManager.shippingContract.updateShipping(updateShipping);
            return Ok(update);
        }

        [HttpPost("deleteShipping")]
        public async Task<IActionResult> deleteShipping(DeleteShippingViewModel deleteShipping)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteShipping");
            var delete = await _serviceManager.shippingContract.deleteShipping(deleteShipping);
            return Ok(delete);
        }


    }
}

