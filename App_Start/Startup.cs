using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;
using System;
using System.Threading.Tasks;
using System.Timers;

[assembly: OwinStartup(typeof(Yuce.App_Start.Startup))]

namespace Yuce.App_Start
{
    
    public class Startup
    {
      
        public void Configuration(IAppBuilder app)
        {
            
            app.UseCors(CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {

                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 3600000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var p = NinjectWebCommon.GetInstance<IGetFilmsFromWebService>();

            var s = p.Get();

            var t = NinjectWebCommon.GetInstance<IFilmService>();

            t.SaveFilmsFromWeb(s);
        }
    }
}
