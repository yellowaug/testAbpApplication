using System.Linq;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;

namespace MyAbpDemo.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MyAbpDemoApplicationModule))]
    public class MyAbpDemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MyAbpDemoApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
            ConfigureSwaggerUi();
        }
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration.EnableSwagger
                (cfg =>
                {
                    cfg.SingleApiVersion("v1", "TestHome");
                    cfg.ResolveConflictingActions(apidesc => apidesc.First());
                }).EnableSwaggerUi();
        }
    }
}
