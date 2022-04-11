using System.Threading.Tasks;
using Vineforce.TusharBhagat.Configuration.Dto;

namespace Vineforce.TusharBhagat.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
