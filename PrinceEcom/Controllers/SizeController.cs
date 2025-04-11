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
    public class SizeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public SizeController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdSize/{sizeId}")]
        public async Task<IActionResult> getByIdSize(Guid sizeId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdSize sizeId ${sizeId}");
            var getByIdSize = await _serviceManager.sizeContract.getByIdSize(sizeId);
            if (getByIdSize.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Size Found");
            }
            return Ok(getByIdSize);
        }

        [HttpGet("getAllSize")]
        public async Task<IActionResult> getAllSize()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSize");
            var getAllSize = await _serviceManager.sizeContract.getAllSize();
            if (getAllSize.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Size Found");
            }
            return Ok(getAllSize);
        }

        [HttpGet("getAllSizeForUser")]
        public async Task<IActionResult> getAllSizeForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSizeForUser");
            var getAllSize = await _serviceManager.sizeContract.getAllSizeForUser();
            if (getAllSize.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Size Found");
            }
            return Ok(getAllSize);
        }

        [HttpPost("addSize")]
        public async Task<IActionResult> addSize(AddSizeViewModel addSize)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addSize");
            var add = await _serviceManager.sizeContract.addSize(addSize);
            return Ok(add);
        }

        [HttpPost("updateSize")]
        public async Task<IActionResult> updateSize(UpdateSizeViewModel updateSize)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateSize");
            var update = await _serviceManager.sizeContract.updateSize(updateSize);
            return Ok(update);
        }

        [HttpPost("deleteSize")]
        public async Task<IActionResult> deleteSize(DeleteSizeViewModel deleteSize)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteSize");
            var delete = await _serviceManager.sizeContract.deleteSize(deleteSize);
            return Ok(delete);
        }
    }
}

