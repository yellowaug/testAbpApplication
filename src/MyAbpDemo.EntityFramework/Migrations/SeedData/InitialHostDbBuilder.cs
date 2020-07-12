using MyAbpDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MyAbpDemo.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MyAbpDemoDbContext _context;

        public InitialHostDbBuilder(MyAbpDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
