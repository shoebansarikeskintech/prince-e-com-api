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
    public class RoleMenuController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public RoleMenuController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdRoleMenu/{roleMenuId}")]
        public async Task<IActionResult> getByIdRoleMenu(Guid roleMenuId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdRoleMenu roleMenuId ${roleMenuId}");
            var getByIdRoleMenu = await _serviceManager.roleMenuContract.getByIdRoleMenu(roleMenuId);
            if (getByIdRoleMenu.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No RoleMenu Found");
            }
            return Ok(getByIdRoleMenu);
        }

        [HttpGet("getAllRoleMenu")]
        public async Task<IActionResult> getAllRoleMenu()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllRoleMenu");
            var getAllRoleMenu = await _serviceManager.roleMenuContract.getAllRoleMenu();
            if (getAllRoleMenu.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No RoleMenu Found");
            }
            return Ok(getAllRoleMenu);
        }

        [HttpPost("addRoleMenu")]
        public async Task<IActionResult> addRoleMenu(AddRoleMenuViewModel addRoleMenuViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addRoleMenu");
            var addRoleMenu = await _serviceManager.roleMenuContract.addRoleMenu(addRoleMenuViewModel);
            return Ok(addRoleMenu);
        }

        [HttpPost("updateRoleMenu")]
        public async Task<IActionResult> updateRoleMenu(UpdateRoleMenuViewModel updateRoleMenuViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateRoleMenu");
            var updateRoleMenu = await _serviceManager.roleMenuContract.updateRoleMenu(updateRoleMenuViewModel);
            return Ok(updateRoleMenu);
        }

        [HttpPost("deleteRoleMenu")]
        public async Task<IActionResult> deleteRoleMenu(DeleteRoleMenuViewModel deleteRoleMenuViewModel)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteRoleMenu");
            var deleteRoleMenu = await _serviceManager.roleMenuContract.deleteRoleMenu(deleteRoleMenuViewModel);
            return Ok(deleteRoleMenu);
        }
    }
}
