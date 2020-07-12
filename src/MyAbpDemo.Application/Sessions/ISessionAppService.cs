using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpDemo.Sessions.Dto;

namespace MyAbpDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
