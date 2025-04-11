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
    public class SubCategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public SubCategoryController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdSubCategory/{subCategoryId}")]
        public async Task<IActionResult> getByIdSubCategory(Guid subCategoryId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdSubCategory subCategoryId ${subCategoryId}");
            var getByIdSubCategory = await _serviceManager.subCategoryContract.getByIdSubCategory(subCategoryId);
            if (getByIdSubCategory.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sub Category Found");
            }
            return Ok(getByIdSubCategory);
        }
        
        [HttpGet("getAllSubCategory")]
        public async Task<IActionResult> getAllSubCategory()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSubCategory");
            var getAllSubCategory = await _serviceManager.subCategoryContract.getAllSubCategory();
            if (getAllSubCategory.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sub Category Found");
            }
            return Ok(getAllSubCategory);
        }

        [HttpGet("getAllSubCategoryForUser")]
        public async Task<IActionResult> getAllSubCategoryForUser()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSubCategoryForUser");
            var getAllSubCategory = await _serviceManager.subCategoryContract.getAllSubCategoryForUser();
            if (getAllSubCategory.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sub Category Found");
            }
            return Ok(getAllSubCategory);
        }

        [HttpPost("addSubCategory")]
        public async Task<IActionResult> addSubCategory(AddSubCategoryViewModel addSubCategory)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addSubCategory");
            var add = await _serviceManager.subCategoryContract.addSubCategory(addSubCategory);
            return Ok(add);
        }

        [HttpPost("updateSubCategory")]
        public async Task<IActionResult> updateSubCategory(UpdateSubCategoryViewModel updateSubCategory)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateSubCategory");
            var update = await _serviceManager.subCategoryContract.updateSubCategory(updateSubCategory);
            return Ok(update);
        }

        [HttpPost("deleteSubCategory")]
        public async Task<IActionResult> deleteSubCategory(DeleteSubCategoryViewModel deleteSubCategory)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteSubCategory");
            var delete = await _serviceManager.subCategoryContract.deleteSubCategory(deleteSubCategory);
            return Ok(delete);
        }
    }
}
