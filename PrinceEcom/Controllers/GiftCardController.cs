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
    public class GiftCardController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public GiftCardController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getByIdGiftCard/{giftCardId}")]
        public async Task<IActionResult> getByIdGiftCard(Guid giftCardId)
        {
            _logger.logInfo($" {LoggingEvents.getByIdItem} getByIdGiftCard giftCardId ${giftCardId}");
            var getByIdGiftCard = await _serviceManager.giftCardContract.getByIdGiftCard(giftCardId);
            if (getByIdGiftCard.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No GiftCard Found");
            }
            return Ok(getByIdGiftCard);
        }

        [HttpGet("getAllGiftCard")]
        public async Task<IActionResult> getAllGiftCard()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllGiftCart");
            var getAllGiftCard = await _serviceManager.giftCardContract.getAllGiftCard();
            if (getAllGiftCard.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No GiftCard Found");
            }
            return Ok(getAllGiftCard);
        }

        [HttpPost("addGiftCard")]
        public async Task<IActionResult> addGiftCard(AddGiftCardViewModel addGiftCard)
        {
            _logger.logInfo($" {LoggingEvents.addItem} addGiftCard");
            var add = await _serviceManager.giftCardContract.addGiftCard(addGiftCard);
            return Ok(add);
        }

        [HttpPost("updateGiftCard")]
        public async Task<IActionResult> updateGiftCard(UpdateGiftCardViewModel updateGiftCard)
        {
            _logger.logInfo($" {LoggingEvents.updateItem} updateGiftCard");
            var update = await _serviceManager.giftCardContract.updateGiftCard(updateGiftCard);
            return Ok(update);
        }

        [HttpPost("deleteGiftCard")]
        public async Task<IActionResult> deleteGiftCard(DeleteGiftCardViewModel deleteGiftCard)
        {
            _logger.logInfo($" {LoggingEvents.deleteItem} deleteGiftCard");
            var delete = await _serviceManager.giftCardContract.deleteGiftCard(deleteGiftCard);
            return Ok(delete);
        }
    }
}
