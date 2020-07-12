using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyAbpDemo.Configuration.Dto;

namespace MyAbpDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyAbpDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
