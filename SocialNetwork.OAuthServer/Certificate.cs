using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace SocialNetwork.OAuthServer
{
    public class Certificate
    {
        public static X509Certificate2 Load()
        {
            var assembly = typeof(Certificate).Assembly;
            var dsdsa = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            using (var stream = assembly.GetManifestResourceStream(AppDomain.CurrentDomain.BaseDirectory + "idsrv3test.pfx"))
            {
                return new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + "idsrv3test.pfx", "idsrv3test");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}