using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SocialNetwork.OAuthServer
{
    public class InMemoryManager
    {
        public List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser
                {
                    Subject = "Jean-Subject",
                    Username = "jean.llopes@outlook.com",
                    Password = "password",
                    Enabled = true,
                    Provider = "Jean-Provider",
                    ProviderId = "Jean-Id",
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Jean-Lopes"),
                        new Claim(Constants.ClaimTypes.GivenName, "Jean"),
                        new Claim(Constants.ClaimTypes.NickName, "Jean")
                    }

                }
            };
        }

        public IEnumerable<Scope> GetScope()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "Read",
                    DisplayName ="Read-User-Data"
                }
            };
        }

        public IEnumerable<Client> getClients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "socialnetwork",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName = "SocialNetwork",
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>()
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    },
                    Enabled = true
                }
            };
        }
    }
}