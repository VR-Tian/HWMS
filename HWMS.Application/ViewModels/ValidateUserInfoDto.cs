using System;
using System.Collections.Generic;
using System.Text;

namespace HWMS.Application.ViewModels
{
    public class ValidateUserInfoDto
    {
        public ValidateUserInfoDto(bool IsValidated, UserViewModel userViewModel)
        {
            this.IsValidated = IsValidated;
            this.UserInfo = userViewModel;
        }
        public bool IsValidated { get; }
        public UserViewModel UserInfo { get; set; }
    }
}
