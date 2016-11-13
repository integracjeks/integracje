using AppHarbor;
using Microsoft.Owin;
using Owin;
using System;
using System.Web;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


            //// use the actual HTTP response body content in place of responseBody
            //var responseBody = "access_token=:access_token&token_type=:token_type";
            //var tokenData = HttpUtility.ParseQueryString(responseBody);
            //var accessToken = tokenData["access_token"];

            

            //// create an Api instance with the token obtained from oAuth
            //var api = new AppHarborClient(new AuthInfo("tokem"));
            


            //// get a list of all applications
            //var applications = api.GetApplications();

            //foreach (var application in applications)
            //{
            //    Console.WriteLine(string.Format("Application name: {0}, Url: {1}",
            //        application.Name, application.Url));
            //}
        }
    }
}
