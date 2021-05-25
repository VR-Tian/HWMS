using System;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models.Access
{
    public abstract class User : Entity
    {
        public string UserName { get; set; }

        public string Passwork { get; set; }
    }
}
