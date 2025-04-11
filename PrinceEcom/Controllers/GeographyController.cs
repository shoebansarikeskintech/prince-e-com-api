using LoggerService;
using Microsoft.AspNetCore.Mvc;
using ServiceContract;
using PrinceEcom.Utils;
using System.Net;
using ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeographyController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public GeographyController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getAllCountry")]
        public async Task<IActionResult> getAllCountryMethod()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCountryMethod");
            var getAllShippingMethod = await _serviceManager.geographyContract.getAllCountryMethod();
            if (getAllShippingMethod.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No County List");
            }
            return Ok(getAllShippingMethod);
        }
        [HttpGet("getAllState")]
        public async Task<IActionResult> getAllStateMethod(int Fk_CountryId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllStateMethod");
            var getAllShippingMethod = await _serviceManager.geographyContract.getAllStateMethod(Fk_CountryId);
            if (getAllShippingMethod.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No County List");
            }
            return Ok(getAllShippingMethod);
        }
        [HttpGet("getAllCity")]
        public async Task<IActionResult> getAllCityMethod(int Fk_StateId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getAllCityMethod Fk_StateId ${Fk_StateId}");
            var getByIdShipping = await _serviceManager.geographyContract.getAllCityMethod(Fk_StateId);
            if (getByIdShipping.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No City Found");
            }
            return Ok(getByIdShipping);
        }
    }
}
