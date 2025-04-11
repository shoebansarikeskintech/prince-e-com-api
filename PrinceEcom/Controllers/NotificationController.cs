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
    public class NotificationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public NotificationController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdNotification/{notificationId}")]
        public async Task<IActionResult> getByIdNotification(Guid notificationId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdNotification notificationId ${notificationId}");
            var getByIdNotification = await _serviceManager.notificationContract.getByIdNotification(notificationId);
            if (getByIdNotification.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Notification Found");
            }
            return Ok(getByIdNotification);
        }

        [HttpGet("getAllNotification")]
        public async Task<IActionResult> getAllNotification()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllNotification");
            var getAllNotification = await _serviceManager.notificationContract.getAllNotification();
            if (getAllNotification.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sub Category Found");
            }
            return Ok(getAllNotification);
        }

        [HttpGet("getAllNotificationForUser")]
        public async Task<IActionResult> getAllSubCategoryForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllNotificationForUser");
            var getAllNotification = await _serviceManager.notificationContract.getAllNotificationForUser();
            if (getAllNotification.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Notification Found");
            }
            return Ok(getAllNotification);
        }

        [HttpPost("addNotification")]
        public async Task<IActionResult> addNotification(AddNotificationViewModel addNotification)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addNotification");
            var add = await _serviceManager.notificationContract.addNotification(addNotification);
            return Ok(add);
        }

        [HttpPost("updateNotification")]
        public async Task<IActionResult> updateNotification(UpdateNotificationViewModel updateNotification)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateNotification");
            var update = await _serviceManager.notificationContract.updateNotification(updateNotification);
            return Ok(update);
        }

        [HttpPost("deleteNotification")]
        public async Task<IActionResult> deleteNotification(DeleteNotificationViewModel deleteNotification)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteNotification");
            var delete = await _serviceManager.notificationContract.deleteNotification(deleteNotification);
            return Ok(delete);
        }
    }
}
