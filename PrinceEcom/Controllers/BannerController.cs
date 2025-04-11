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
   
    public class BannerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public BannerController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdBanner/{bannerId}")]
        [Authorize]
        public async Task<IActionResult> getByIdBanner(Guid bannerId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdBanner bannerId ${bannerId}");
            var getByIdBanner = await _serviceManager.bannerContract.getByIdBanner(bannerId);
            if (getByIdBanner.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Banner Found");
            }
            return Ok(getByIdBanner);
        }



        [HttpGet("getAllBanner")]
        [Authorize]
        public async Task<IActionResult> getAllBanner()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllBanner");
            var getAllBanner = await _serviceManager.bannerContract.getAllBanner();
            if (getAllBanner.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Banner Found");
            }
            return Ok(getAllBanner);
        }

        [HttpPost("addBanner")]
        [Authorize]
        public async Task<IActionResult> addBanner(AddBannerViewModel addBanner)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addShippingMethod");
            var add = await _serviceManager.bannerContract.addBanner(addBanner);
            return Ok(add);
        }

        //[HttpPost("addBanner")]
        //[Authorize]
        //public async Task<IActionResult> addBanner(AddBannerViewModel addBanner)
        //{
        //    _logger.logInfo($" {LoggingEvents.addItem} addBanner");
        //    var add = await _serviceManager.bannerContract.addBanner(addBanner);
        //    return Ok(add);
        //}

        [HttpPost("updateBanner")]
        [Authorize]
        public async Task<IActionResult> updateBanner(UpdateBannerViewModel updateBanner)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateBanner");
            var update = await _serviceManager.bannerContract.updateBanner(updateBanner);
            return Ok(update);
        }

        [HttpPost("deleteBanner")]
        [Authorize]
        public async Task<IActionResult> deleteBanner(DeleteBannerViewModel deleteBanner)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteBanner");
            var delete = await _serviceManager.bannerContract.deleteBanner(deleteBanner);
            return Ok(delete);
        }
    }
}
