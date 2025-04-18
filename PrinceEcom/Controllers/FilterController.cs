﻿using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrinceEcom.Utils;
using ServiceContract;
using System.Net;

namespace PrinceEcom.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public FilterController(IServiceManager serviceManager, ILoggerManager logger, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("getAllSortBy")]
        public async Task<IActionResult> getAllSortBy()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllSortBy");
            var getAllSortBy = await _serviceManager.filterContract.getAllSortBy();
            if (getAllSortBy.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllSortBy);
        }

        [HttpGet("getAllFilter")]
        public async Task<IActionResult> getAllFilter()
        {
            _logger.logInfo($" {LoggingEvents.getAllItem} getAllFilter");
            var getAllFilter = await _serviceManager.filterContract.getAllFilter();
            if (getAllFilter.statusCode == (int)HttpStatusCode.NotFound)
            {
                _logger.logWarn($"{LoggingEvents.getItemNotFound},No Sort By Found");
            }
            return Ok(getAllFilter);
        }
    }
}
