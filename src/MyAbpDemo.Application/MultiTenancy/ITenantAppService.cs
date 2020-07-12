using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbpDemo.MultiTenancy.Dto;

namespace MyAbpDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
