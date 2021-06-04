using System;
using System.Collections.Generic;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models.Access
{
    public class UserRoleMapping : Entity<int>
    {
        public int RoleId { get; private set; }

        public int UserId { get; private set; }

        public DateTime CreateTime { get; private set; }
    }
}