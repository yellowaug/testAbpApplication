using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpDemo.Authorization.Accounts.Dto;

namespace MyAbpDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
