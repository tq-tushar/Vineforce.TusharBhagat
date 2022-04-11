using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Vineforce.TusharBhagat.Configuration.Dto;

namespace Vineforce.TusharBhagat.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TusharBhagatAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
