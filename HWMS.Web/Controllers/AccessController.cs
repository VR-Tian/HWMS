using System;
using System.Text;
using System.Web;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HWMS.Web.Controllers
{

    [Route("/api/Access")]
    public class AccessController : ControllerBase
    {
        private readonly IAuthenticateService _AuthService;
        public AccessController(IAuthenticateService authService)
        {
            this._AuthService = authService;
        }
        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            //TODO:验证身份信息
            string token;
            if (this._AuthService.IsAuthenticated(request, out token))
            {
                // this.HttpContext.Response.Headers.Add("Authorization", "Bearer "+token);
                this.HttpContext.Response.Cookies.Append("token", token);
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }

        [Route("Logout")]
        [HttpPost]
        [Authorize]
        public IActionResult Logout()
        {
            //doto user login
            this.HttpContext.Response.Cookies.Delete("token");
            return Ok();
        }

    }
}