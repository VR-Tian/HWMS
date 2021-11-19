using System;
using System.Collections.Generic;
using System.Security.Claims;
using Newtonsoft.Json;

namespace HWMS.Application.ViewModels
{
    public class TokenManagementOptions
    {
        public const string Position = "tokenManagement";

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }

        [JsonProperty("refreshExpiration")]
        public int RefreshExpiration { get; set; }


        public const string UserID = "HWMS_UserID";
    }

    /// <summary>
    /// 身份凭据管理
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    public class TokenManagement<TUser> where TUser : class, new()
    {
        
        /// <summary>
        /// 实例化凭据对象
        /// </summary>
        /// <param name="claims"></param>
        public TokenManagement(IEnumerable<Claim> claims=null)
        {

        }

        private string GetToken()
        {
            throw new NotImplementedException();
        }
    }
}