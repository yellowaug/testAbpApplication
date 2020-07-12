using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MyAbpDemo.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MyAbpDemo.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MyAbpDemo.EntityFramework.MyAbpDemoDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MyAbpDemo";
        }

        protected override void Seed(MyAbpDemo.EntityFramework.MyAbpDemoDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
