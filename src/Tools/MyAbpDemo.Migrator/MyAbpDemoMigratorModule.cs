using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MyAbpDemo.EntityFramework;

namespace MyAbpDemo.Migrator
{
    [DependsOn(typeof(MyAbpDemoDataModule))]
    public class MyAbpDemoMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MyAbpDemoDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}