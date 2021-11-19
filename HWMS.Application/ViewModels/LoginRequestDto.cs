using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HWMS.Application.ViewModels
{
    public class LoginRequestDto
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }


        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class LoginResponseDto
    { 
        public string UserName { get; set; }

        public string Token { get; set; }
    }
}