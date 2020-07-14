using System.Linq;
using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using Hangfire;
using MyAbpDemo.Authorization.Roles;
using MyAbpDemo.Authorization.Users;
using MyAbpDemo.Roles.Dto;
using MyAbpDemo.TestAutomap;
using MyAbpDemo.TestAutomap.Dto;
using MyAbpDemo.TestCache;
using MyAbpDemo.TestCache.Dto;
using MyAbpDemo.Users.Dto;

namespace MyAbpDemo
{
    [DependsOn(typeof(MyAbpDemoCoreModule), typeof(AbpAutoMapperModule), typeof(AbpHangfireModule))]
    public class MyAbpDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.UseHangfire(configuration =>
            {
                configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
                    opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CompanyInput, TestCompanyDto>();
                cfg.CreateMap<TestCompanyDto, TestCompany>();

                cfg.CreateMap<TestTable, TestTableCacheDto>()
                .ForMember(u => u.PhoneNum, opts => opts.MapFrom(dto => dto.PhoneNum))
                .ForMember(u => u.FullName, opts => opts.MapFrom(dto => dto.FullName));                
            });
        }
    }
}
