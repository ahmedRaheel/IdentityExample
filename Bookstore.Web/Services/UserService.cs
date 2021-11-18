using Bookstore.EnterpriseLibrary.Constants;
using Bookstore.Web.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookstore.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserService> _logger;

        public UserService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, 
                           ILogger<UserService> logger) 
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var idpClient = _httpClientFactory.CreateClient(StringConstant.Http_Client_Idp);

            var response = await idpClient.GetDiscoveryDocumentAsync();
            if (response.IsError) 
            {
                _logger.LogError(response.Exception.ToString());
                throw new HttpRequestException("Something went wrong while requesting the access token");                
            }
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var userInfoResponse = await idpClient.GetUserInfoAsync(
              new UserInfoRequest
              {
                  Address = response.UserInfoEndpoint,
                  Token = accessToken
              });

            if (userInfoResponse.IsError)
            {
                _logger.LogError(userInfoResponse.Exception.ToString());
                throw new HttpRequestException("Something went wrong while getting user info");
            }

            var userInfoDictionary = new Dictionary<string, string>();

            foreach (var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }

            return new UserInfo(userInfoDictionary);
        }
    }
}
