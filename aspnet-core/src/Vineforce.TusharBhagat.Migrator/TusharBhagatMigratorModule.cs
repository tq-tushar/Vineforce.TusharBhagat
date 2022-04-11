using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Vineforce.TusharBhagat.Configuration;
using Vineforce.TusharBhagat.EntityFrameworkCore;
using Vineforce.TusharBhagat.Migrator.DependencyInjection;

namespace Vineforce.TusharBhagat.Migrator
{
    [DependsOn(typeof(TusharBhagatEntityFrameworkModule))]
    public class TusharBhagatMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TusharBhagatMigratorModule(TusharBhagatEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(TusharBhagatMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TusharBhagatConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TusharBhagatMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
