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
    public class AppRoleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public AppRoleController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getByIdAppRole/{appRoleId}")]
        [Authorize]
        public async Task<IActionResult> getByIdAppRole(Guid appRoleId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdAppRole appRoleId ${appRoleId}");
            var getByIdAppRole = await _serviceManager.appRoleContract.getByIdAppRole(appRoleId);
            if (getByIdAppRole.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No App Role Found");
            }
            return Ok(getByIdAppRole);
        }

        [HttpGet("getAllAppRole")]
        [Authorize]

        public async Task<IActionResult> getAllAppRole()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllAppRole");
            var getAllAppRole = await _serviceManager.appRoleContract.getAllAppRole();
            if (getAllAppRole.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No App Role Found");
            }
            return Ok(getAllAppRole);
        }

        [HttpPost("addAppRole")]
        [Authorize]

        public async Task<IActionResult> addAppRole(AddAppRoleViewModel addAppRoleViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addAppRole");
            var addAppRole = await _serviceManager.appRoleContract.addAppRole(addAppRoleViewModel);
            return Ok(addAppRole);
        }

        [HttpPost("updateAppRole")]
        [Authorize]
        public async Task<IActionResult> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateAppRole");
            var updateAppRole = await _serviceManager.appRoleContract.updateAppRole(updateAppRoleViewModel);
            return Ok(updateAppRole);
        }

        [HttpPost("deleteAppRole")]
        [Authorize]
        public async Task<IActionResult> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} deleteAppRole");
            var deleteAppRole = await _serviceManager.appRoleContract.deleteAppRole(deleteAppRoleViewModel);
            return Ok(deleteAppRole);
        }

        //new ticket 

        [HttpGet("getAllTicket")]
        public async Task<IActionResult> getAllTicket()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllTicket");
            var getAllTicket = await _serviceManager.appRoleContract.getAllTicket();
            if (getAllTicket.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Ticket Role Found");
            }
            return Ok(getAllTicket);
        }

        [HttpPost("addTicket")]

        public async Task<IActionResult> addTicket(AddTicketViewModel addTicketViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addTicket");
            var addTicket = await _serviceManager.appRoleContract.addTicket(addTicketViewModel);
            return Ok(addTicket);
        }

        [HttpPost("updateTicket")]
        public async Task<IActionResult> updateTicket(UpdateTicketViewModel updateTicketViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateTicket");
            var updateTicket = await _serviceManager.appRoleContract.updateTicket(updateTicketViewModel);
            return Ok(updateTicket);
        }

        [HttpPost("deleteTicket")]
        public async Task<IActionResult> deleteTicket(DeleteTicketViewModel deleteTicketViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} deleteTicket");
            var deleteTicket = await _serviceManager.appRoleContract.deleteTicket(deleteTicketViewModel);
            return Ok(deleteTicket);
        }

        //ticket Reply 

        [HttpGet("getAllTicketReply")]
        public async Task<IActionResult> getAllTicketReply()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllTicketReply");
            var getAllTicketReply = await _serviceManager.appRoleContract.getAllTicketReply();
            if (getAllTicketReply.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Ticeker Reply Role Found");
            }
            return Ok(getAllTicketReply);
        }

        [HttpPost("addTicketReply")]

        public async Task<IActionResult> addTicketReply(AddTicketReplyViewModel addTicketReplyViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addAppRole");
            var addTicketReply = await _serviceManager.appRoleContract.addTicketReply(addTicketReplyViewModel);
            return Ok(addTicketReply);
        }

        [HttpPost("updateTicketReply")]
        public async Task<IActionResult> updateTicketReply(UpdateTicketReplyViewModel updateTicketReplyViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateTicketReply");
            var updateTicketReply = await _serviceManager.appRoleContract.updateTicketReply(updateTicketReplyViewModel);
            return Ok(updateTicketReply);
        }

        [HttpPost("deleteTicketReply")]
        public async Task<IActionResult> deleteTicketReply(DeleteTicketReplyViewModel deleteTicketReplyViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} deleteAppRole");
            var deleteTicketReply = await _serviceManager.appRoleContract.deleteTicketReply(deleteTicketReplyViewModel);
            return Ok(deleteTicketReply);
        }
    }
}
