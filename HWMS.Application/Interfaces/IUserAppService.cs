using System;
using System.Collections.Generic;
using HWMS.Application.ViewModels;

namespace HWMS.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        void Register(UserViewModel userViewModel);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetByInfo(LoginRequestDto req);
        void Update(UserViewModel userViewModel);
        void Remove(Guid id);
        List<NavigationMenuViewModel> GetRolePermissionOfUser(int userid);

        List<RoleViewModel> GetRoleOfUser(UserViewModel user);
        bool IsValid(LoginRequestDto req);
    }
}
