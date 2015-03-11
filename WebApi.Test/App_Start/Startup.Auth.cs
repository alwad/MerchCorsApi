using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Api.carmax.org
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            // Configure the application for OAuth based flow
            
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = false, 
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
            

        }
    }
}
