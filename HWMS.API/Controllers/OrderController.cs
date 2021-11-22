using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using HWMS.Application.Interfaces;
using HWMS.Application.Services;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Core.Notifications;
using HWMS.DoMain.EventHandlers;
using HWMS.DoMain.Events;
using HWMS.API.Extension;
using HWMS.API.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HWMS.API.Controllers
{

    /// <summary>
    /// 订单资源接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
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

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var queryOrder = this._OrderAppService.GetById(id);
            if (queryOrder == null)
            {
                return NotFound();
            }
            this._OrderAppService.Remove(queryOrder.Id);
            return NoContent();
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModel">修改订单的参数</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, OrderViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }
            var queryOrder = this._OrderAppService.GetById(id);
            if (queryOrder == null)
            {
                return NotFound();
            }
            this._OrderAppService.Update(viewModel);
            return NoContent();
        }


        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<OrderViewModel> Get()
        {
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>() { new OrderViewModel() { City = "GZ", County = "LW" }, new OrderViewModel() { City = "HZ", County = "BL" }, new OrderViewModel() { City = "XG", County = "TL1" } };

            return Ok();
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(OrderViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderViewModel> Get(Guid id)
        {
            var queryOrder = this._OrderAppService.GetById(id);
            if (queryOrder == null)
            {
                return NotFound();
            }
            return Ok(queryOrder);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="viewModel">创建订单参数</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] OrderViewModel viewModel)
        {
            await this._OrderAppService.RegisterAsyn(viewModel);
            if (this._Notification.HasNotifications())
            {
                var infoMsg = _Notification.GetNotifications();
                _Notification.Dispose();
                return BadRequest(infoMsg);
            }
            return CreatedAtAction(nameof(Get), new { id = this._OrderRegiestHandler.orderRegistered.Id });
        }


        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="formFiles">根据上传文件创建订单</param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost("File")]
        [CheckFileUpload(IsSaveFile = true)]
        public async Task<IActionResult> Create([FromForm] List<IFormFile> formFiles, [FromHeader] string title)
        {
            foreach (var formFile in formFiles)
            {
                DataTable tb = null;
                List<TextModel> getList = null;
                using (var memoryStream = new MemoryStream())
                {
                    await formFile.CopyToAsync(memoryStream);
                    tb = await FileService.ExecuteReadExcelOfStream(memoryStream);
                    getList = tb.ChinaColumnToList<TextModel>();
                    //FileService fileService = new FileService();
                    //tb = await fileService.ExecuteReadExcelForStream(memoryStream);
                }
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(getList));
            }
            return CreatedAtRoute(nameof(Get), new { id = this._OrderRegiestHandler.orderRegistered.Id });
        }
    }
}