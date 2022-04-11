using Vineforce.TusharBhagat.Debugging;

namespace Vineforce.TusharBhagat
{
    public class TusharBhagatConsts
    {
        public const string LocalizationSourceName = "TusharBhagat";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7778a1735ed14833ab74901b889173fb";
    }
}
