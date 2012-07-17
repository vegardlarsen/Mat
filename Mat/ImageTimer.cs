using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Mat.Common;
using Mat.Helpers;
using SignalR;

namespace Mat
{
    [assembly:WebActivator.PreApplicationStartMethod(typeof(ImageTimer), "Start")]
    public static class ImageTimer
    {
        private static readonly Timer _timer = new Timer(OnTimerElapsed);
        private static readonly JobHost _jobHost = new JobHost();

        public static void Start()
        {
            _timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private static void OnTimerElapsed(object sender)
        {
            _jobHost.DoWork(() =>
                                {
                                    var context = GlobalHost.ConnectionManager.GetHubContext<ImageHub>();
                                    // todo: fix, will break:
                                    var manager = QueueManagerFactory.FromClient(String.Empty);
                                    context.Clients.newImage(manager.Next());
                                });
        }
    }
}