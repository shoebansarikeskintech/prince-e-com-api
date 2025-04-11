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
    public class AddressController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public AddressController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getDefaultAddress/{userId}")]
        public async Task<IActionResult> getDefaultAddress(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getDefaultAddress userId ${userId}");
            var getDefaultAddress = await _serviceManager.addressContract.getDefaultAddress(userId);
            if (getDefaultAddress.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Address Found");
            }
            return Ok(getDefaultAddress);
        }

        [HttpGet("getAddressList")]
        public async Task<IActionResult> getAddressList(Guid userId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAddressList userId ${userId}");
            var getAddressList = await _serviceManager.addressContract.getAddressList(userId);
            if (getAddressList.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Brand Found");
            }
            return Ok(getAddressList);
        }

        
        [HttpPost("addAddress")]
        public async Task<IActionResult> addAddress(AddAddressViewModel addAddress)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addAddress");
            var add = await _serviceManager.addressContract.addAddress(addAddress);
            return Ok(add);
        }

        [HttpPost("updateAddress")]
        public async Task<IActionResult> updateAddress(UpdateAddressViewModel updateAddress)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateAddress");
            var update = await _serviceManager.addressContract.updateAddress(updateAddress);
            return Ok(update);
        }

        [HttpPost("deleteAddress")]
        public async Task<IActionResult> deleteAddress(DeleteAddressViewModel deleteAddress)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteAddress");
            var delete = await _serviceManager.addressContract.deleteAddress(deleteAddress);
            return Ok(delete);
        }
    }
}

