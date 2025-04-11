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
    public class CustomerManagementController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public CustomerManagementController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllCustomer")]
        public async Task<IActionResult> getAllCustomer()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCustomer");
            var getAllCustomer = await _serviceManager.customerManagementContract.getAllCustomer();
            if (getAllCustomer.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Banner Found");
            }
            return Ok(getAllCustomer);
        }

        [HttpGet("getAllOrderByUser")]
        public async Task<IActionResult> getAllOrderByUser(string username)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllOrderByUser");
            var getAllCustomer = await _serviceManager.customerManagementContract.getAllOrderByUser(username);
            if (getAllCustomer.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Order Found");
            }
            return Ok(getAllCustomer);
        }

        [HttpGet("getAppUserProfileDetails")]
        public async Task<IActionResult> getAppUserProfileDetails(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAppUserProfileDetails");
            var getAllCustomer = await _serviceManager.customerManagementContract.getAppUserProfileDetails(userId);
            if (getAllCustomer.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Profile Found");
            }
            return Ok(getAllCustomer);
        }

        [HttpPost("appUserUpdateProfile")]
        public async Task<IActionResult> appUserUpdateProfile(UpdateProfileViewModel updateProfile)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} appUserUpdateProfile");
            var update = await _serviceManager.customerManagementContract.appUserUpdateProfile(updateProfile);
            return Ok(update);
        }


        [HttpPost("appUserUpdatePassword")]
        public async Task<IActionResult> appUserUpdatePassword(UpdatePasswordViewModel addAppUser)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} appUserUpdatePassword");
            var update = await _serviceManager.customerManagementContract.appUserUpdatePassword(addAppUser);
            return Ok(update);
        }

    }
}
