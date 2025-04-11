using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;
using ViewModel;
using static ViewModel.ConcernViewModel;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcernController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ConcernController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllConcern")]
        public async Task<IActionResult> getAllConcern()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} SpGetAllIngredient");
            var getAllIngredientMethod = await _serviceManager.concernContract.getAllConcernMethod();
            if (getAllIngredientMethod.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Ingredient Method List");
            }
            return Ok(getAllIngredientMethod);
        }

        [HttpPost("addConcern")]
        [Authorize]
        public async Task<IActionResult> addConcern(AddConcernViewModel addConcernViewModel)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addIngredientMethod");
            var add = await _serviceManager.concernContract.addConcernMethod(addConcernViewModel);
            return Ok(add);
        }

        [HttpPost("updateConcern")]
        [Authorize]
        public async Task<IActionResult> updateConcern(UpdateConcernViewModel updateConcernMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} updateIngredientMethod");
            var add = await _serviceManager.concernContract.updateConcernMethod(updateConcernMethod);
            return Ok(add);
        }

        [HttpPost("deleteConcern")]
        [Authorize]
        public async Task<IActionResult> deleteConcern(DeleteConcernViewModel deleteConcernMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} deleteIngredientMethod");
            var delete = await _serviceManager.concernContract.deleteConcernMethod(deleteConcernMethod);
            return Ok(delete);
        }
    }
}
