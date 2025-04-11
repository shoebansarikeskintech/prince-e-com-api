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
    public class ColorController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ColorController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdColor/{colorId}")]
        public async Task<IActionResult> getByIdColor(Guid colorId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdColor colorId ${colorId}");
            var getByIdColor = await _serviceManager.colorContract.getByIdColor(colorId);
            if (getByIdColor.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Color Found");
            }
            return Ok(getByIdColor);
        }

        [HttpGet("getAllColor")]
        public async Task<IActionResult> getAllColor()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllColor");
            var getAllColor = await _serviceManager.colorContract.getAllColor();
            if (getAllColor.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Color Found");
            }
            return Ok(getAllColor);
        }

        [HttpGet("getAllColorForUser")]
        public async Task<IActionResult> getAllColorForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllColorForUser");
            var getAllColorForUser = await _serviceManager.colorContract.getAllColorForUser();
            if (getAllColorForUser.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Color Found");
            }
            return Ok(getAllColorForUser);
        }

        [HttpPost("addColor")]
        public async Task<IActionResult> addColor(AddColorViewModel addColor)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addColor");
            var add = await _serviceManager.colorContract.addColor(addColor);
            return Ok(add);
        }

        [HttpPost("updateColor")]
        public async Task<IActionResult> updateColor(UpdateColorViewModel updateColor)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateColor");
            var update = await _serviceManager.colorContract.updateColor(updateColor);
            return Ok(update);
        }

        [HttpPost("deleteColor")]
        public async Task<IActionResult> deleteColor(DeleteColorViewModel deleteColor)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteColor");
            var delete = await _serviceManager.colorContract.deleteColor(deleteColor);
            return Ok(delete);
        }
    }
}
