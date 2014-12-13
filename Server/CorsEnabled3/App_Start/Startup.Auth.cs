using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using System.Configuration;

namespace CorsEnabled3
{
	public partial class Startup
	{
        public void ConfigureAuth(IAppBuilder app)
        {

            //TODO: Replace the web config values with your client ID and audience after configuring the app in Azure AD
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Audience = ConfigurationManager.AppSettings["ida:Audience"],
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"]
					
                });

        }
	}
}