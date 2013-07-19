using System;
using System.Threading;
using Mat.Common;
using Mat.Helpers;
using SignalR;

namespace Mat
{
    public static class MediaTimer
    {
        private static readonly Timer Timer = new Timer(OnTimerElapsed);
        private static readonly JobHost JobHost = new JobHost();

        public static void Start()
        {
            Timer.Change(TimeSpan.Zero, MatConfigurationSection.GetSettings().DefaultImageTime);
        }

        private static void OnTimerElapsed(object sender)
        {
            JobHost.DoWork(() =>
                                {
                                    var hub = GlobalHost.ConnectionManager.GetHubContext<MediaHub>();
                                    // todo: fix, will break:
                                    var manager = QueueManagerFactory.FromClient(String.Empty);
                                    hub.Clients.newImage(manager.Next(), false, MediaHub.DisplayTime);
                                });
        }
    }
}