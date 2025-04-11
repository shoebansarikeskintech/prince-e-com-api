using Common;
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
    public class MenuController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        private readonly ExtractToken extractToken;
        public MenuController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
            extractToken = new ExtractToken(configuration);
        }
        [HttpGet("getByIdMenu/{menuId}")]
        public async Task<IActionResult> getByIdMenu(Guid menuId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdMenu menuId ${menuId}");
            var getByIdMenu = await _serviceManager.menuContract.getByIdMenu(menuId);
            if (getByIdMenu.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Menu Found");
            }
            return Ok(getByIdMenu);
        }

        [HttpGet("getMenuByUserRole")]
        public async Task<IActionResult> getMenuByUserRole()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            TokenDetailsViewModel loginViewModel = extractToken.ExtractUserDetailsFromToken(token);
            _logger.logInfo($" {LoggingEvents.getByIdItem} getMenuByUserRole");
            var getMenuByUserRole = await _serviceManager.menuContract.getMenuByUserRole(loginViewModel.username);
            if (getMenuByUserRole.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Menu Found");
            }
            return Ok(getMenuByUserRole);
        }

        [HttpGet("getAllMenu")]
        public async Task<IActionResult> getAllMenu()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllMenu");
            var getAllMenu = await _serviceManager.menuContract.getAllMenu();
            if (getAllMenu.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Menu Found");
            }
            return Ok(getAllMenu);
        }

        [HttpPost("addMenu")]
        public async Task<IActionResult> addMenu(AddMenuViewModel addMenuViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addMenu");
            var addMenu = await _serviceManager.menuContract.addMenu(addMenuViewModel);
            return Ok(addMenu);
        }

        [HttpPost("updateMenu")]
        public async Task<IActionResult> updateMenu(UpdateMenuViewModel updateMenuViewModel)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateMenu");
            var updateMenu = await _serviceManager.menuContract.updateMenu(updateMenuViewModel);
            return Ok(updateMenu);
        }

        [HttpPost("deleteMenu")]
        public async Task<IActionResult> deleteMenu(DeleteMenuViewModel deleteMenuViewModel)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteItem");
            var deleteMenu = await _serviceManager.menuContract.deleteMenu(deleteMenuViewModel);
            return Ok(deleteMenu);
        }

        [HttpGet("getAllMenuOfSubMenu")]
        public async Task<IActionResult> getAllMenuOfSubMenu()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllMenuOfSubMenu");
            var getAllMenu = await _serviceManager.menuContract.getAllMenuOfSubMenu();
            if (getAllMenu.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Menu Found");
            }
            return Ok(getAllMenu);
        }

    }
}
