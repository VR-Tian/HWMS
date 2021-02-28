using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Commands.Order;
using HWMS.DoMain.Core.Bus;
using HWMS.DoMain.Interfaces;

namespace HWMS.Application.Services
{
    /// <summary>
    /// 订单服务
    /// </summary>
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _Mapper;
        private readonly IMediatorHandler _Bus;
        private readonly IUnitOfWork _UnitOfWork;
        public OrderAppService(IUnitOfWork uow, IOrderRepository IOrderRepository, IMapper Mapper, IMediatorHandler bus)
        {
            this._Bus = bus;
            this._OrderRepository = IOrderRepository;
            this._Mapper = Mapper;
            this._UnitOfWork = uow;
        }

        public OrderAppService(IOrderRepository IOrderRepository, IMapper Mapper, IMediatorHandler bus)
        {
            this._Bus = bus;
            this._OrderRepository = IOrderRepository;
            this._Mapper = Mapper;
        }
        public void Dispose()
        {
            this._OrderRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<OrderViewModel> GetAll()
        {

            return this._OrderRepository.GetAll().ProjectTo<OrderViewModel>(_Mapper.ConfigurationProvider).ToList();
            // throw new NotImplementedException();
        }

        public OrderViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(OrderViewModel OrderViewModel)
        {
            //TODO
            //1服务层的职责：只协调（调度）各个业务间的工作流。（直接引用领域实体的不妥之处）
            //2如何验证、在哪里验证实体字段合法性
            //3如何对系统业务字段进行内部赋值。创建时间，唯一ID，订单号等。

            //DDD:
            //领域服务层来完成业务逻辑
            // var registerModel = this._Mapper.Map<Order>(OrderViewModel);
            // this._OrderRepository.Add(registerModel);
            // this._OrderRepository.SaveChanges();


            //通过Mediator处理程序分发命令
            //执行顺序：验证 -> 通知 -> 注册
            var registerCommand = this._Mapper.Map<RegisterOrderCommand>(OrderViewModel);
            this._Bus.SendCommand(registerCommand);

        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderViewModel OrderViewModel)
        {
            throw new NotImplementedException();
        }
    }
}