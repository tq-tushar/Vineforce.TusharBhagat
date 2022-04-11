using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Vineforce.TusharBhagat.Configuration;

namespace Vineforce.TusharBhagat.Web.Host.Startup
{
    [DependsOn(
       typeof(TusharBhagatWebCoreModule))]
    public class TusharBhagatWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TusharBhagatWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TusharBhagatWebHostModule).GetAssembly());
        }
    }
}
