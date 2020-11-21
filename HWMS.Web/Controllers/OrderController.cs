using System;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Core.Notifications;
using MediatR;
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

        private readonly DomainNotificationHandler _Notification;

        public OrderControlle(ILogger<WeatherForecastController> logger, IOrderAppService orderService, INotificationHandler<DomainNotification> notification)
        {
            this._logger = logger;
            this._OrderAppService = orderService;
            this._Notification = (DomainNotificationHandler)notification;
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
            if (this._Notification.HasNotifications())
            {
                var infoMsg = _Notification.GetNotifications();
                _Notification.Dispose();
            }
            return Ok();
        }
    }
}