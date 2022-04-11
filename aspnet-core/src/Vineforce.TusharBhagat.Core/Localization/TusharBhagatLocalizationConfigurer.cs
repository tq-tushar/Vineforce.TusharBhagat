using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Vineforce.TusharBhagat.Localization
{
    public static class TusharBhagatLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TusharBhagatConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TusharBhagatLocalizationConfigurer).GetAssembly(),
                        "Vineforce.TusharBhagat.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
