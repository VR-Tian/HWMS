using System;
using System.Threading.Tasks;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Core.Notifications;
using HWMS.DoMain.EventHandlers;
using HWMS.DoMain.Events;
using HWMS.Web.Extension;
using HWMS.Web.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HWMS.Web.Controllers
{
    [IsAuthorized]
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _OrderAppService;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DomainNotificationHandler _Notification;
        private readonly OrderEventHandler _OrderRegiestHandler;

        public OrderController(ILogger<WeatherForecastController> logger,
        IOrderAppService orderService, INotificationHandler<DomainNotification> notification,
        INotificationHandler<OrderRegisteredEvent> orderEvent)
        {
            this._logger = logger;
            this._OrderAppService = orderService;
            this._Notification = (DomainNotificationHandler)notification;
            this._OrderRegiestHandler = (OrderEventHandler)orderEvent;

        }

        
        [HttpGet]
        public IActionResult Get()
        {
            if (this.HavePermission(""))
            {

            }
            return Ok();
        }

        [HttpGet]
        [Route("id", Name = nameof(Get))]
        public IActionResult Get(Guid id)
        {
            return Ok(this._OrderAppService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderViewModel viewModel)
        {
            await this._OrderAppService.RegisterAsyn(viewModel);
            if (this._Notification.HasNotifications())
            {
                var infoMsg = _Notification.GetNotifications();
                _Notification.Dispose();
                return BadRequest(infoMsg);
            }
            //this._OrderRegiestHandler.orderRegisteredEvent;
            return CreatedAtRoute(nameof(Get), new { id = this._OrderRegiestHandler.orderRegistered.Id });
        }
    }
}