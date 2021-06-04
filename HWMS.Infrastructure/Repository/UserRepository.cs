using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models.Access;
using HWMS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HWMS.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HWMSContext accessContext) : base(accessContext)
        {

        }

        public IQueryable<NavigationMenu> GetRolePermissionOfUser(int userid)
        {

            var dbContext = this._Context as HWMSContext;
            var temp = dbContext.UserRoleMappings.Where(t => t.Id == 1);
            var permissionInfo = (from userRoleMapping in dbContext.UserRoleMappings
                                  join roleMenuMapping in dbContext.RoleMenuPermissions
                                   on userRoleMapping.RoleId equals roleMenuMapping.RoleId
                                  join navigationmenu in dbContext.NavigationMenus
                                  on roleMenuMapping.NavigationMenuId equals navigationmenu.Id
                                  where userRoleMapping.UserId == userid
                                  select navigationmenu);

            return permissionInfo;
        }

        public IQueryable<Role> GetRoleOfUser(int userid)
        {

            var dbContext = this._Context as HWMSContext;
            var temp = dbContext.UserRoleMappings.Where(t => t.Id == 1);
            var roleinfo = (from userRoleMapping in dbContext.UserRoleMappings
                                  join rolesInfo in dbContext.Roles
                                   on userRoleMapping.RoleId equals rolesInfo.Id

                                  where userRoleMapping.UserId == userid
                                  select rolesInfo);

            return roleinfo;
        }
    }
}