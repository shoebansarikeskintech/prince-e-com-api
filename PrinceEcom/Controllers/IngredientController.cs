using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;
using ViewModel;

namespace PrinceEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public IngredientController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllIngredient")]
        public async Task<IActionResult> getAllIngredient()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} SpGetAllIngredient");
            var getAllIngredientMethod = await _serviceManager.ingredientContract.getAllIngredientMethod();
            if (getAllIngredientMethod.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Ingredient Method List");
            }
            return Ok(getAllIngredientMethod);
        }

        [HttpGet("getAllIngredientActive")]
        public async Task<IActionResult> getAllIngredientActive()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllIngredientActiveMethod");
            var getAllIngredientMethod = await _serviceManager.ingredientContract.getAllIngredientActiveMethod();
            if (getAllIngredientMethod.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Ingredient Method List");
            }
            return Ok(getAllIngredientMethod);
        }

        [HttpPost("addIngredient")]
        [Authorize]
        public async Task<IActionResult> addIngredient(AddIngredientViewModel addIngredientViewModelMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addIngredientMethod");
            var add = await _serviceManager.ingredientContract.addIngredientMethod(addIngredientViewModelMethod);
            return Ok(add);
        }

        [HttpPost("updateIngredient")]
        [Authorize]
        public async Task<IActionResult> updateIngredient(UpdateIngredientViewModel updateIngredientMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} updateIngredientMethod");
            var add = await _serviceManager.ingredientContract.updateIngredientMethod(updateIngredientMethod);
            return Ok(add);
        }

        [HttpPost("deleteIngredient")]
        [Authorize]
        public async Task<IActionResult> deleteIngredient(DeleteIngredientViewModel deleteIngredientMethod)
        {
            _logger.logInfo($" {LoggingEvents.addItem} deleteIngredientMethod");
            var delete = await _serviceManager.ingredientContract.deleteIngredientMethod(deleteIngredientMethod);
            return Ok(delete);
        }
    }
}
