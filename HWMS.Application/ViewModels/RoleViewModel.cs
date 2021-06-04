using System;

namespace HWMS.Application.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; private set; }
    }
}