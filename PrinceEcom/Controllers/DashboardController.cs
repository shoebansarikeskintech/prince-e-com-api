using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public DashboardController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        
        [HttpGet("getAllBannerForUser")]
        public async Task<IActionResult> getAllBannerForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllBannerForUser");
            var getAllBannerForUser = await _serviceManager.dashboardContract.getAllBannerForUser();
            if (getAllBannerForUser.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Banner Found");
            }
            return Ok(getAllBannerForUser);
        }

        [HttpGet("getAllCategories")]
        public async Task<IActionResult> getAllCategories()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCategories");
            var getAllCategories = await _serviceManager.dashboardContract.getAllCategories();
            if (getAllCategories.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No All Categories Found");
            }
            return Ok(getAllCategories);
        }

        [HttpGet("getShopByCategory")]
        public async Task<IActionResult> getShopByCategory()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getShopByCategory");
            var getShopByCategory = await _serviceManager.dashboardContract.getShopByCategory();
            if (getShopByCategory.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get Shop By Category Found");
            }
            return Ok(getShopByCategory);
        }
    }
}
