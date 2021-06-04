using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using HWMS.Application.Interfaces;
using HWMS.Application.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HWMS.Application.Services
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserAppService _UserService;
        private readonly TokenManagement _TokenManagement;

        public TokenAuthenticationService(IUserAppService userService, IOptions<TokenManagement> tokenManagement)
        {
            _UserService = userService;
            _TokenManagement = tokenManagement.Value;
        }
        public bool IsAuthenticated(LoginRequestDto request, out string token)
        {
            var userinfo = _UserService.GetByInfo(request);
            token = string.Empty;
            if (userinfo == null)
                return false;
            //用户身份授权
            var roleOfUser = _UserService.GetRoleOfUser(userinfo);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Username),
                new Claim("ACCESS_ROLECODE",string.Join("|",roleOfUser.Select(t=>t.RoleCode))),
                new Claim("USER_ID", userinfo.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_TokenManagement.Secret));//使用配置密钥进行加密

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(_TokenManagement.Issuer,
            _TokenManagement.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_TokenManagement.AccessExpiration), signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return true;
        }
    }
}