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
      
        public async Task<IActionResult> addAppRole(AddAppRoleViewModel addAppRoleViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addAppRole");
            var addAppRole = await _serviceManager.appRoleContract.addAppRole(addAppRoleViewModel);
            return Ok(addAppRole);
        }

        [HttpPost("updateAppRole")]
        public async Task<IActionResult> updateAppRole(UpdateAppRoleViewModel updateAppRoleViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateAppRole");
            var updateAppRole = await _serviceManager.appRoleContract.updateAppRole(updateAppRoleViewModel);
            return Ok(updateAppRole);
        }

        [HttpPost("deleteAppRole")]
        public async Task<IActionResult> deleteAppRole(DeleteAppRoleViewModel deleteAppRoleViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} deleteAppRole");
            var deleteAppRole = await _serviceManager.appRoleContract.deleteAppRole(deleteAppRoleViewModel);
            return Ok(deleteAppRole);
        }
    }
}
