using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWMS.DoMain.Models;
using HWMS.DoMain.Models.Access;

namespace HWMS.DoMain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<NavigationMenu> GetRolePermissionOfUser(int userid);

        IQueryable<Role> GetRoleOfUser(int userid);
    }
}