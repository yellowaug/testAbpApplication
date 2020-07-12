using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MyAbpDemo.EntityFramework;
using StackExchange.Profiling.EntityFramework6;

namespace MyAbpDemo
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(MyAbpDemoCoreModule))]
    public class MyAbpDemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            MiniProfilerEF6.Initialize();
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyAbpDemoDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
