using Bookstore.EnterpriseLibrary.Constants;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.IdentityServer.Configuration
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[] {
                 new Client              
                 {
                     ClientId= "Bookstore_Web_Client",
                     ClientName = "Web User",
                     AllowedGrantTypes = GrantTypes.Hybrid,
                     AllowRememberConsent = false,
                     RedirectUris = new List<string>()
                     {
                         "https://localhost:5005/signin-oidc"
                     },
                     PostLogoutRedirectUris = new List<string>() 
                     {
                         "https://localhost:5005/signout-callback-oidc"
                     },
                     ClientSecrets =
                     {
                         new Secret("secret".Sha256())
                     },
                     AllowedScopes= new List<string>() 
                     {
                         IdentityServerConstants.StandardScopes.OpenId, 
                         IdentityServerConstants.StandardScopes.Profile,
                         IdentityServerConstants.StandardScopes.Address,
                         IdentityServerConstants.StandardScopes.Email,
                         StringConstant.Scope_Role_Value,
                         StringConstant.Scope_Book_Api_Value
                     }
                 }
            };

        public static IEnumerable<ApiScope> Scopes => new ApiScope[] 
        {
            new ApiScope("bookstoreAPI", "BookStore API")
         
        };
       public static IEnumerable<ApiResource> Resources => new ApiResource[]
       {           

       };
      public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
      {
           new IdentityResources.OpenId(), 
           new IdentityResources.Profile(),
           new IdentityResources.Address(),
           new IdentityResources.Email(),
           new IdentityResource(StringConstant.Scope_Role_Value, StringConstant.Scope_Role_Text, new List<string>() { StringConstant.Scope_Role_Value })
      };
     public static List<TestUser> TestUsers => new List<TestUser>()
     {
          
     };
    }
}
