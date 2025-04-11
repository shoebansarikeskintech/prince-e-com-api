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
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public PaymentController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getCheckPaymentStatus")]
        public async Task<IActionResult> getCheckPaymentStatus(Guid orderId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getCheckPaymentStatus");
            var getCheckPaymentStatus = await _serviceManager.paymentContract.getCheckPaymentStatus(orderId);
            if (getCheckPaymentStatus.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No get Check Payment Status Found");
            }
            return Ok(getCheckPaymentStatus);
        }

        [HttpGet("getPaymentList")]
        public async Task<IActionResult> getPaymentList()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getPaymentList");
            var getPaymentList = await _serviceManager.paymentContract.getPaymentList();
            if (getPaymentList.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Data Found");
            }
            return Ok(getPaymentList);
        }

        [HttpGet("getPaymentMode")]
        public async Task<IActionResult> getPaymentMode()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getPaymentMode");
            var getPaymentList = await _serviceManager.paymentContract.getPaymentMode();
            if (getPaymentList.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Data Found");
            }
            return Ok(getPaymentList);
        }

        [HttpPost("addPaymentMode")]
        public async Task<IActionResult> addPaymentMode(AddPaymentModeViewModel addPaymentModeViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addAppRole");
            var addPaymentMode = await _serviceManager.paymentContract.addPaymentMode(addPaymentModeViewModel);
            return Ok(addPaymentMode);
        }

        [HttpPost("updatePaymentMode")]
        public async Task<IActionResult> updatePaymentMode(UpdatePaymentModeViewModel updatePaymentModeViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updatePaymentMode");
            var updatePaymentMode = await _serviceManager.paymentContract.updatePaymentMode(updatePaymentModeViewModel);
            return Ok(updatePaymentMode);
        }

        [HttpPost("deletePaymentMode")]
        public async Task<IActionResult> deletePaymentMode(DeletePaymentModeViewModel deletePaymentModeViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} deletePaymentMode");
            var deletePaymentMode = await _serviceManager.paymentContract.deletePaymentMode(deletePaymentModeViewModel);
            return Ok(deletePaymentMode);
        }
    }
}

