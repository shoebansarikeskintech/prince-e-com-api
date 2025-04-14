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

        [HttpPost("updateRatinReview")]
        [Authorize]
        public async Task<IActionResult> updateRatinReview(UpdateReviewRatingViewModel uodateRatingReview)
        {
            _logger.logInfo($"{LoggingEvents.addItem} UpdateRatingReview");
            var add = await _serviceManager.ratingReviewContract.updateRatinReview(uodateRatingReview);
            return Ok(add);

        }
    }
}
