using System;
using System.Configuration;
﻿using Abp.Owin;
using MyAbpDemo.Api.Controllers;
using MyAbpDemo.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(Startup))]

namespace MyAbpDemo.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();
           
            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //LoginPath = new PathString("/Account/Login"),
                LoginPath = new PathString(@"/swagger/ui/index"),
                // by setting following values, the auth cookie will expire after the configured amount of time (default 14 days) when user set the (IsPermanent == true) on the login
                ExpireTimeSpan = new TimeSpan(int.Parse(ConfigurationManager.AppSettings["AuthSession.ExpireTimeInDays.WhenPersistent"] ?? "14"), 0, 0, 0),
                SlidingExpiration = bool.Parse(ConfigurationManager.AppSettings["AuthSession.SlidingExpirationEnabled"] ?? bool.FalseString)
 
            });
           
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.MapSignalR();
            app.UseHangfireDashboard();
            //ENABLE TO USE HANGFIRE dashboard (Requires enabling Hangfire in MyAbpDemoWebModule)
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() } //You can remove this line to disable authorization
            //});
        }
    }
}
