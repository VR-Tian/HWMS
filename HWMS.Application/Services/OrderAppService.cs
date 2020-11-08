using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Interfaces;

namespace HWMS.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _Mapper;
        public OrderAppService(IOrderRepository IOrderRepository, IMapper Mapper)
        {
            this._OrderRepository = IOrderRepository;
            this._Mapper = Mapper;
        }
        public void Dispose()
        {
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