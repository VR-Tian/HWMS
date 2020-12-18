using System;
using System.Collections.Generic;
using HWMS.Application.ViewModels;

namespace HWMS.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        void Register(UserViewModel userViewModel);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(Guid id);
        void Update(UserViewModel userViewModel);
        void Remove(Guid id);
    }
}
