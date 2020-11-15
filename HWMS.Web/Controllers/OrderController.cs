using System;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HWMS.Web.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderControlle : ControllerBase
    {
        private readonly IOrderAppService _OrderAppService;
        private readonly ILogger<WeatherForecastController> _logger;
        public OrderControlle(ILogger<WeatherForecastController> logger, IOrderAppService orderService)
        {
            this._logger = logger;
            this._OrderAppService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._OrderAppService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderViewModel viewModel)
        {
            this._OrderAppService.Register(viewModel);
            return Ok();
        }
    }
}