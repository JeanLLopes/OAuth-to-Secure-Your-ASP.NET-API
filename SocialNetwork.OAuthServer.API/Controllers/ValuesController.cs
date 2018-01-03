using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SocialNetwork.OAuthServer.API.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize]
        public Dictionary<string, string> Get()
        {
            //STRING RETURN
            var listDic = new Dictionary<string, string>();
            //GET THE TOKEN INFORMATIONS
            var claimsPrincipal = User as ClaimsPrincipal;
            //var username
            foreach (var itemclaimsPrincipal in claimsPrincipal.Claims)
            {
                listDic.Add(itemclaimsPrincipal.Type.ToString(), itemclaimsPrincipal.Value.ToString());
            }
            return listDic;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
