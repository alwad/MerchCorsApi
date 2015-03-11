using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.carmax.org.Controllers
{

    [EnableCors(origins: "http://merchcorsweb.azurewebsites.net", headers: "*", methods: "*",
        PreflightMaxAge = 2147483647)]
    [Authorize]

    public class Resource2Controller : ApiController
    {
        static Dictionary<string, int> ClientCounter = new Dictionary<string, int>();
        static Dictionary<string, int> GetCounter = new Dictionary<string, int>();

        // GET api/values
        public IEnumerable<string> Get()
        {
            var user = User as ClaimsPrincipal;

            var client = user.Claims.Where(c => c.Type == "https://www.carmax.org/auth/client").FirstOrDefault();

            if (!GetCounter.ContainsKey(client.Value))
                GetCounter.Add(client.Value, 0);

            GetCounter[client.Value]++;

            return new string[] { "hello oAuth2 world", string.Format("hello user {0}.  Get counter: {1}", User.Identity.Name, GetCounter[client.Value]) };
        }

        public IEnumerable<string> Put()
        {
 
            List<string> ret = new List<string>() {"hello oAuth2 world"};

            var user = User as ClaimsPrincipal;
            var name = user.Claims.Where(c => c.Type == "http://carmax.org/ADFS/Attribute/displayName").FirstOrDefault();
            var client = user.Claims.Where(c => c.Type == "https://www.carmax.org/auth/client").FirstOrDefault();

            
            
            if (!ClientCounter.ContainsKey(client.Value))
                ClientCounter.Add(client.Value, 0);

            ClientCounter[client.Value]++;

            ret.Add("Client counter : " + ClientCounter[client.Value].ToString());

            if (name != null)
                ret.Add(string.Format("hello user {0}.", name.Value));
            return ret;
            
        }
    }
}
