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
    public class BrandController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public BrandController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdBrand/{brandId}")]
        public async Task<IActionResult> getByIdBrand(Guid brandId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdBrand brandId ${brandId}");
            var getByIdBrand = await _serviceManager.brandContract.getByIdBrand(brandId);
            if (getByIdBrand.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Brand Found");
            }
            return Ok(getByIdBrand);
        }

        [HttpGet("getAllBrand")]
        public async Task<IActionResult> getAllBrand()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllBrand");
            var getAllBrand = await _serviceManager.brandContract.getAllBrand();
            if (getAllBrand.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Brand Found");
            }
            return Ok(getAllBrand);
        }

        [HttpGet("getAllBrandForUser")]
        public async Task<IActionResult> getAllBrandForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllBrandForUser");
            var getAllBrand = await _serviceManager.brandContract.getAllBrandForUser();
            if (getAllBrand.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Brand Found");
            }
            return Ok(getAllBrand);
        }

        [HttpPost("addBrand")]
        public async Task<IActionResult> addBrand(AddBrandViewModel addBrand)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addBrand");
            var add = await _serviceManager.brandContract.addBrand(addBrand);
            return Ok(add);
        }

        [HttpPost("updateBrand")]
        public async Task<IActionResult> updateBrand(UpdateBrandViewModel updateBrand)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateBrand");
            var update = await _serviceManager.brandContract.updateBrand(updateBrand);
            return Ok(update);
        }

        [HttpPost("deleteBrand")]
        public async Task<IActionResult> deleteBrand(DeleteBrandViewModel deleteBrand)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteBrand");
            var delete = await _serviceManager.brandContract.deleteBrand(deleteBrand);
            return Ok(delete);
        }
    }
}

