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

            //GET THE CERTIFICATE FROM web.config
            var certificate = Convert.FromBase64String(ConfigurationManager.AppSettings["SigningCertificate"]);

            var optionsIdentityServer = new IdentityServerOptions()
            {
                SigningCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2()
            };

            app.UseIdentityServer()
        }
    }
}
