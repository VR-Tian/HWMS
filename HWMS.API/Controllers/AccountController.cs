using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HWMS.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticateService _AuthService;
        private readonly IOptions<TokenManagementOptions> _Options;
        public AccountController(IAuthenticateService authService, IOptionsSnapshot<TokenManagementOptions> options)
        {
            this._AuthService = authService;
            this._Options = options;
        }
        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, "administeration"),
                new Claim(ClaimTypes.Name,"admin"),
                new Claim(TokenManagementOptions.UserID, Guid.NewGuid().ToString())
            };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok();
        }

        [Route("Token")]
        [HttpGet]
        public async Task<IActionResult> Token([FromQuery] LoginRequestDto request)
        {
            #region Ŀǰ���ڽ�ɫ��Ȩ��������ϵͳ��̬��Ȩ����
            //1ϵͳĳЩ��ԴȨ�ް�����������Ϊ�������п���

            #endregion
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Options.Value.Secret));
            JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                ///TODO �ڿͻ��˲���Ҫtoken�������Ϣ�������ļ��ܣ���ҵ��API·��ǰ�����ս���������Identity��
                new Claim(ClaimTypes.Name,"admin"),
                new Claim(ClaimTypes.Role, request.Username),
                new Claim(ClaimTypes.DateOfBirth,"21"),
                new Claim(TokenManagementOptions.UserID, Guid.NewGuid().ToString())
            };
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _Options.Value.Issuer, audience: this._Options.Value.Audience, claims: claims, expires: DateTime.UtcNow.AddSeconds(30), signingCredentials: credentials);
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                Token = JwtTokenHandler.WriteToken(token),
                UserName = request.Username
            };
            return await Task.FromResult(Ok(loginResponseDto));
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