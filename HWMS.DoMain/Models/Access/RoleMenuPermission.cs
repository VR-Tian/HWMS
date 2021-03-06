using System;
using System.Collections.Generic;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models.Access
{
    public class RoleMenuPermission : Entity<int>
    {
        public int RoleId { get; private set; }

        public int NavigationMenuId { get; private set; }

        public DateTime CreateTime { get; private set; }

        public NavigationMenu NavigationMenu { get; set; }
    }
}