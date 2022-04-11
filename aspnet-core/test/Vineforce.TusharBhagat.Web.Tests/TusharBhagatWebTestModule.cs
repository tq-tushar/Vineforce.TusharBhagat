using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Vineforce.TusharBhagat.EntityFrameworkCore;
using Vineforce.TusharBhagat.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Vineforce.TusharBhagat.Web.Tests
{
    [DependsOn(
        typeof(TusharBhagatWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TusharBhagatWebTestModule : AbpModule
    {
        public TusharBhagatWebTestModule(TusharBhagatEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TusharBhagatWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TusharBhagatWebMvcModule).Assembly);
        }
    }
}