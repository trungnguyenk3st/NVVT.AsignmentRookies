using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("rookieshop.api", "Rookie Shop API"),
                  new ApiScope("admin"),
             };

        public static IEnumerable<Client> Clients(Dictionary<string, string> clientUrls) =>
            new[]
            {
                 new Client
                {
                    ClientId = "ro.client",
                    ClientName = "Resource Owner Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api.myshop" }
                },
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //// scopes that client has access to
                    AllowedScopes = { "rookieshop.api" }
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = {$"{clientUrls["Mvc"]}/signin-oidc" },

                    PostLogoutRedirectUris = {$"{clientUrls["Mvc"]}/signout-callback-oidc" },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieshop.api",
                        /*"admin"*/
                    }
                },
                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"{clientUrls["Swagger"]}" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieshop.api"
                    }
                },
                new Client
                {
                    ClientName = "react_admin",
                    ClientId = "react_app",
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RequireClientSecret = false,
                 

                    RedirectUris = 
                    {
                        $"{clientUrls["React"]}/signin-oidc"                    
                    },
                    FrontChannelLogoutUri = $"{clientUrls["React"]}/signout-oidc",


                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/unauthorized",
                        $"{clientUrls["React"]}/signout-callback-oidc",
                        $"{clientUrls["React"]}"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{clientUrls["React"]}"
                    },
                    AllowedScopes = { "openid", "profile", "rookieshop.api" },
                   
                },
            };
    }
}
