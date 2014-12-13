using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Cors;
using System.IO;
using System.Web;

[assembly: OwinStartup(typeof(CorsEnabled3.Startup))]

namespace CorsEnabled3
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
      
    }
}
