using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using System.Configuration;

[assembly: OwinStartup(typeof(SocialNetwork.OAuthServer.Startup))]

namespace SocialNetwork.OAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var inMemoryManager = new InMemoryManager();

            var factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(inMemoryManager.getClients())
                .UseInMemoryScopes(inMemoryManager.GetScope())
                .UseInMemoryUsers(inMemoryManager.GetUsers());


            var optionsIdentityServer = new IdentityServerOptions()
            {
                SigningCertificate = Certificate.Load(),
                RequireSsl = false, //CHANGE TO TRUE IN PRODUCTION
                Factory = factory
            };

            app.UseIdentityServer(optionsIdentityServer);


            //FOR MAKE REQUEST
            //POST
            //POST /connect/token HTTP/1.1
            // Host: localhost: 53866
            //Content - Type: application / x - www - form - urlencoded
            //Cache - Control: no - cache
            //Postman - Token: b9318482 - 7bbb - 0d25 - 71dc - c68c572069e8
            //client_id = socialnetwork & client_secret = secret & grant_type = password & scope = openid & username = jean.llopes % 40outlook.com & password = password

            //AND YOUR RESPONSE
            //{
            //"access_token": "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSIsImtpZCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUzODY2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1Mzg2Ni9yZXNvdXJjZXMiLCJleHAiOjE1MTQ5NTA5NjMsIm5iZiI6MTUxNDk0NzM2MywiY2xpZW50X2lkIjoic29jaWFsbmV0d29yayIsInNjb3BlIjoib3BlbmlkIiwic3ViIjoiSmVhbi1TdWJqZWN0IiwiYXV0aF90aW1lIjoxNTE0OTQ3MzYzLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.fY3qEyNMuB_oQGBCvnOX_iaAnc28Trbpf0ln24w5Bo1mfLK9cS-4GXK-WrjbBU6RgfhjNpT5GZfZ0T8FKjbZAN37Vk9sxDp1Z34gWJTsjRE8f_EJhQg4rh9Fzc13EQPTy9DQcASRiMWf7wBlKyEz79pN7ejQd8SjXBPtD47NBXjYhA_pVyUhHAN8QKkoYyQIANBTOPuPBeHkj_XPvAW-VUfEjzAzqiOzt-BsxZYmd1rqBUut6__YiNdqLWW5a_OwMNVylFz0utkfFvd-COoYUEzGFWvE2IcasRfa4jZ5YSdetaiOwIgH0gxzl3lTR4Ltk4sr_5Vf8r1Ka_jNo4ddQQ",
            //"expires_in": 3600,
            //"token_type": "Bearer"
            //}
        }
    }
}
