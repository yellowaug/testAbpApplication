using System.Linq;
using MyAbpDemo.EntityFramework;
using MyAbpDemo.MultiTenancy;

namespace MyAbpDemo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly MyAbpDemoDbContext _context;

        public DefaultTenantCreator(MyAbpDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
