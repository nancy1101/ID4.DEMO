using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dave.IdentityProvider
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Nancy",
                    Password = "111",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "南西"),
                        new Claim("family_name", "江")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "QQ",
                    Password = "QQ",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "可可"),
                        new Claim("family_name", "王")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvcclient",
                    ClientName = "MVC 客户端",
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    // 登陆后跳转到这
                    RedirectUris =
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
