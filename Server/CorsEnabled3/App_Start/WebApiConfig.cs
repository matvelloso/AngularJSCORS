using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CorsEnabled3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //TODO: Replace this URL by your client URL. Never end this with a '/'. Ever.
            var cors = new EnableCorsAttribute("https://corsenabledclient3.azurewebsites.net", "*", "*");
            config.EnableCors(cors);
        }
    }
}
