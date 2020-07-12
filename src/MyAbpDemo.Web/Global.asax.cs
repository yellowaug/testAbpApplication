using System;
using System.Threading;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Abp.WebApi.Validation;
using Castle.Facilities.Logging;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;

namespace MyAbpDemo.Web
{
    public class MvcApplication : AbpWebApplication<MyAbpDemoWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            MiniProfilerEF6.Initialize();
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );            
            base.Application_Start(sender, e);
        }

    }
}
