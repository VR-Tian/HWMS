using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HWMS.Application.ViewModels;

namespace HWMS.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void Register(OrderViewModel OrderViewModel);
        Task RegisterAsyn(OrderViewModel OrderViewModel);
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(Guid id);
        void Update(OrderViewModel OrderViewModel);
        void Remove(Guid id);
    }
}
