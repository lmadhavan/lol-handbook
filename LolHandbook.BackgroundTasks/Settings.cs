using Windows.Storage;

namespace LolHandbook.BackgroundTasks
{
    public static class Settings
    {
        public static string LastPatchVersion
        {
            get
            {
                return ApplicationData.Current.RoamingSettings.Values["lastPatchVersion"] as string;
            }

            set
            {
                ApplicationData.Current.RoamingSettings.Values["lastPatchVersion"] = value;
            }
        }
    }
}
