using System;
using System.Collections.Generic;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models.Access
{
    public class User : Entity<int>
    {
        public string UserName { get; set; }

        public string Passwork { get; set; }

        public List<UserRoleMapping> RoleMappings { get; private set; }
    }
}
