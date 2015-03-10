using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CorsEnabled3.Controllers
{

    //TODO: Replace this URL by your client URL. Never end this with a '/'. Ever.
    [EnableCors("*", "*", "*", SupportsCredentials = false)]
    [Authorize]
    public class ValuesController : ApiController
    {
        public class Test
        {
            public int id { get; set; }
            public string test { get; set; }

            public override string ToString()
            {
                return string.Format("{0}, {1}", id, test);
            }
        }

        public IEnumerable<string> Get()
        {
            //This example returns all claims found in the request
            string[] result = (from Claim claim in ClaimsPrincipal.Current.Claims
                               select claim.Type + ":" + claim.Value).ToArray();

            return result;

        }

        public string Get(int id)
        {
            return "value";
        }

        public Test Post(Test text)
        {
            return text;
           
        }

        public Test Put(int id, Test text)
        {
            return text;
        }

        public void Delete(int id)
        {
           
        }


      

    }
}
