using Abp.AutoMapper;
using Vineforce.TusharBhagat.Authentication.External;

namespace Vineforce.TusharBhagat.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
