using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpDemo.Configuration.Dto;

namespace MyAbpDemo.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}