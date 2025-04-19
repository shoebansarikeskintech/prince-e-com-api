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
    public class DiscountController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public DiscountController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [HttpGet("getByIdDiscount/{discountId}")]
        public async Task<IActionResult> getByIdDiscount(Guid discountId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdDiscount discountId ${discountId}");
            var getByIdDiscount = await _serviceManager.discountContract.getByIdDiscount(discountId);
            if (getByIdDiscount.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Discount Found");
            }
            return Ok(getByIdDiscount);
        }

        [HttpGet("getAllDiscount")]
        public async Task<IActionResult> getAllDiscount()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllDiscount");
            var getAllDiscount = await _serviceManager.discountContract.getAllDiscount();
            if (getAllDiscount.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Discount Found");
            }
            return Ok(getAllDiscount);
        }

        [HttpPost("addDiscount")]
        public async Task<IActionResult> addDiscount(AddDiscountViewModel addDiscount)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addDiscount");
            var add = await _serviceManager.discountContract.addDiscount(addDiscount);
            return Ok(add);
        }

        [HttpPost("updateDiscount")]
        public async Task<IActionResult> updateDiscount(UpdateDiscountViewModel updateDiscount)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateDiscount");
            var update = await _serviceManager.discountContract.updateDiscount(updateDiscount);
            return Ok(update);
        }

        [HttpPost("deleteDiscount")]
        public async Task<IActionResult> deleteDiscount(DeleteDiscountViewModel deleteDiscount)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteDiscount");
            var delete = await _serviceManager.discountContract.deleteDiscount(deleteDiscount);
            return Ok(delete);
        }



        [HttpGet("getAllCoupon")]
        public async Task<IActionResult> getAllCoupon()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllCoupon");
            var getAllDiscount = await _serviceManager.discountContract.getAllCoupon();
            if (getAllDiscount.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Discount Found");
            }
            return Ok(getAllDiscount);
        }

        [HttpGet("getByIdCoupon")]
        public async Task<IActionResult> getByIdCoupon(Guid couponId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdCoupon discountId ${couponId}");
            var getByIdDiscount = await _serviceManager.discountContract.getByIdCoupon(couponId);
            if (getByIdDiscount.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Discount Found");
            }
            return Ok(getByIdDiscount);
        }

        [HttpPost("addCoupon")]
        public async Task<IActionResult> addCoupon(AddCouponViewModel addCoupon)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addCoupon");
            var add = await _serviceManager.discountContract.addCoupon(addCoupon);
            return Ok(add);
        }

        [HttpPost("updateCoupon")]
        public async Task<IActionResult> updateCoupon(UpdateCouponViewModel updateCoupon)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateCoupon");
            var update = await _serviceManager.discountContract.updateCoupon(updateCoupon);
            return Ok(update);
        }

        [HttpPost("deleteCoupon")]
        public async Task<IActionResult> deleteCoupon(DeleteCouponViewModel deleteCoupon)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteCoupon");
            var delete = await _serviceManager.discountContract.deleteCoupon(deleteCoupon);
            return Ok(delete);
        }
    }
}
