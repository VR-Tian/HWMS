using System;
using System.Collections.Generic;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models.Access
{
    public class Role : Entity<int>
    {
        public int ParentId { get; private set; }
        public string RoleName { get; private set; }
        public string RoleCode { get; private set; }
        public DateTime CreateTime { get; private set; }
        public List<RoleMenuPermission> RoleMenuPermissions { get; private set; }
    }
}