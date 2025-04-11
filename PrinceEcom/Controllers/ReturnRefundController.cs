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
    public class ReturnRefundController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ReturnRefundController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllRefundOrder")]
        public async Task<IActionResult> getAllRefundOrder(Guid adminUserId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllRefundOrder");
            var getAllRefundOrder = await _serviceManager.returnRefundContract.getAllRefundOrder(adminUserId);
            if (getAllRefundOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No get All Refund Order Found");
            }
            return Ok(getAllRefundOrder);
        }

        [HttpPost("updateRefundOrderStatus")]
        public async Task<IActionResult> updateRefundOrderStatus(UpdateRefundOrderStatusViewModel updateRefundOrderStatus)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateRefundOrderStatus");
            var update = await _serviceManager.returnRefundContract.updateRefundOrderStatus(updateRefundOrderStatus);
            return Ok(update);
        }
    }
}
