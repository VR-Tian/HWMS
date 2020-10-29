using System;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Interfaces;

namespace HWMS.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _IOrderRepository;
        public OrderAppService(IOrderRepository IOrderRepository)
        {
            this._IOrderRepository = IOrderRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<OrderViewModel> GetAll()
        {

            //this._IOrderRepository.GetAll().ProjectTo<OrderViewModel>()
            // throw new NotImplementedException();
            return null;
        }

        public OrderViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(OrderViewModel OrderViewModel)
        {
            throw new NotImplementedException();
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