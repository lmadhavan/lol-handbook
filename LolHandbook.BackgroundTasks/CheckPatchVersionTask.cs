using LolHandbook.ViewModels.Services;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace LolHandbook.BackgroundTasks
{
    public sealed class CheckPatchVersionTask : IBackgroundTask
    {
        private const string TaskVersion = "2";
        private const int RefreshIntervalInMinutes = 12 * 60;

        private const string ToastTemplate = @"
            <toast>
                <visual>
                    <binding template=""ToastGeneric"">
                        <text>New League of Legends patch</text>
                        <text></text>
                    </binding>
                </visual>
            </toast>
        ";

        public static void Register()
        {
            BackgroundTaskRegistrar.RegisterBackgroundTask(typeof(CheckPatchVersionTask), TaskVersion, new TimeTrigger(RefreshIntervalInMinutes, false));
        }

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            DataDragonService.InvalidateCache();
            string currentPatchVersion = await DataDragonService.Instance.GetPatchVersionAsync();

            if (currentPatchVersion != null && currentPatchVersion != Settings.LastPatchVersion)
            {
                Settings.LastPatchVersion = currentPatchVersion;
                ShowToastNotification(currentPatchVersion);
            }

            deferral.Complete();
        }

        private static void ShowToastNotification(string patchVersion)
        {
            XmlDocument toastXml = new XmlDocument();
            toastXml.LoadXml(ToastTemplate);

            var text = toastXml.CreateTextNode($"Patch {patchVersion} has been released");
            toastXml.GetElementsByTagName("text")[1].AppendChild(text);

            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
}
