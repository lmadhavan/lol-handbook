using System;
using System.Diagnostics;
using Windows.ApplicationModel.Background;

namespace LolHandbook.BackgroundTasks
{
    internal static class BackgroundTaskRegistrar
    {
        internal async static void RegisterBackgroundTask(Type taskType, string taskVersion, IBackgroundTrigger trigger)
        {
            string taskName = taskType.Name + "_" + taskVersion;

            BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();

            if (status == BackgroundAccessStatus.Denied)
            {
                Debug.WriteLine($"Background access denied, not registering task {taskName}");
                return;
            }


            foreach (BackgroundTaskRegistration registration in BackgroundTaskRegistration.AllTasks.Values)
            {
                if (registration.Name == taskName)
                {
                    Debug.WriteLine($"Background task {taskName} already registered");
                    return;
                }

                if (registration.Name.StartsWith(taskType.Name))
                {
                    Debug.WriteLine($"Unregistering old background task {registration.Name}");
                    registration.Unregister(false);
                }
            }

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = taskName;
            builder.TaskEntryPoint = taskType.FullName;
            builder.SetTrigger(trigger);

            Debug.WriteLine($"Registering new background task {taskName}");
            builder.Register();
        }
    }
}
