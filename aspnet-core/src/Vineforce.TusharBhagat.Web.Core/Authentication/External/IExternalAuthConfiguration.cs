using System.Collections.Generic;

namespace Vineforce.TusharBhagat.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
