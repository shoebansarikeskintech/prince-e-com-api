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
    public class RatingReviewController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public RatingReviewController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpPost("addRatingReview")]
        [Authorize]
        public async Task<IActionResult> addRatingReview(RatingReviewViewModel RatingReview)
        {
            _logger.logInfo($" {LoggingEvents.addItem} AddRatingReview");
            var add = await _serviceManager.ratingReviewContract.addRatingReview(RatingReview);
            return Ok(add);
        }



        [HttpGet("getAllRatingReview")]
        public async Task<IActionResult> getAllRatingReview(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} spGetRatingReview");
            var getAllOrder = await _serviceManager.ratingReviewContract.getAllRatingReview(productId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Review");
            }
            return Ok(getAllOrder);
        }

        [HttpGet("getAllRatingReviewstar")]
        public async Task<IActionResult> getAllRatingReviewstar(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllRatingReviewbyId");
            var getAllOrder = await _serviceManager.ratingReviewContract.getAllRatingReviewbyId(productId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All Review Star");
            }
            return Ok(getAllOrder);
        }


        [HttpPost("updateRatinReview")]
        [Authorize]
        public async Task<IActionResult> updateRatinReview(UpdateReviewRatingViewModel uodateRatingReview)
        {
            _logger.logInfo($"{LoggingEvents.addItem} UpdateRatingReview");
            var add = await _serviceManager.ratingReviewContract.updateRatinReview(uodateRatingReview);
            return Ok(add);

        }

        [HttpPost("addProductFAQ")]
        [Authorize]
        [Authorize]
        public async Task<IActionResult> addFAQ(AddFAQViewModel addFAQ)
        {
            _logger.logInfo($" {LoggingEvents.addItem} AddRatingReview");
            var add = await _serviceManager.ratingReviewContract.addFAQ(addFAQ);
            return Ok(add);
        }

        [HttpGet("getAllFAQByProductId")]
        [Authorize]
        public async Task<IActionResult> getAllFAQByProductId(Guid productId)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllFAQByProductId");
            var getAllOrder = await _serviceManager.ratingReviewContract.getAllFAQByProductId(productId);
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All FAQ");
            }
            return Ok(getAllOrder);
        }

        [HttpGet("getAllProductFAQ")]
        [Authorize]
        public async Task<IActionResult> getAllFAQ()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllFAQ");
            var getAllOrder = await _serviceManager.ratingReviewContract.getAllFAQ();
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All FAQ");
            }
            return Ok(getAllOrder);
        }


        [HttpPost("updateProductFAQ")]
        [Authorize]
        public async Task<IActionResult> updateFAQ(UpdateFAQViewModel updateFAQ)
        {
            _logger.logInfo($"{LoggingEvents.addItem} UpdateRatingReview");
            var add = await _serviceManager.ratingReviewContract.updateFAQ(updateFAQ);
            return Ok(add);

        }

        [HttpPost("deleteProductFAQ")]
        [Authorize]
        public async Task<IActionResult> deleteFAQ(DeleteFAQViewModel deleteFAQ)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllRatingReviewbyId");
            var delete = await _serviceManager.ratingReviewContract.deleteFAQ(deleteFAQ);
            return Ok(delete);
        }


        [HttpPost("addProductSpecification")]
        [Authorize]
        public async Task<IActionResult> addProductSpecification(AddProductSpecificationViewModel addProductSpecification)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addProductSpecification");
            var add = await _serviceManager.ratingReviewContract.addProductSpecification(addProductSpecification);
            return Ok(add);
        }



        [HttpGet("getProductSpecification")]
        [Authorize]
        public async Task<IActionResult> getProductSpecification()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getProductSpecification");
            var getAllOrder = await _serviceManager.ratingReviewContract.getProductSpecification();
            if (getAllOrder.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Get All FAQ");
            }
            return Ok(getAllOrder);
        }


        [HttpPost("updateProductSpecification")]
        [Authorize]
        public async Task<IActionResult> updateProductSpecification(UpdateProductSpecificationViewModel updateProductSpecification)
        {
            _logger.logInfo($"{LoggingEvents.addItem} updateProductSpecification");
            var add = await _serviceManager.ratingReviewContract.updateProductSpecification(updateProductSpecification);
            return Ok(add);

        }

        [HttpGet("deleteProductSpecification")]
        [Authorize]
        public async Task<IActionResult> deleteProductSpecification(DeleteProductSpecificationViewModel deleteProductSpecification)
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} deleteProductSpecification");
            var delete = await _serviceManager.ratingReviewContract.deleteProductSpecification(deleteProductSpecification);
            return Ok(delete);
        }

    }
}
