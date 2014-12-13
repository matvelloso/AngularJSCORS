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
    [EnableCors("https://corsenabledclient3.azurewebsites.net", "*", "*", SupportsCredentials = true)]
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
         
            //This example returns all claims found in the request
            string[] result = (from Claim claim in ClaimsPrincipal.Current.Claims
                               select claim.Type + ":" + claim.Value).ToArray();

            return result ;
        }



    }
}
