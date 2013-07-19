using System.Collections.Generic;
using System.Threading.Tasks;
using Mat.Common;
using SignalR;
using SignalR.Hubs;

namespace Mat.Helpers
{
    public class MediaHub : Hub, IConnected
    {
        #region Connection
        public Task Connect()
        {
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            return Caller.newImage(manager.Current, false, DisplayTime);
        }

        public Task Reconnect(IEnumerable<string> groups)
        {
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            return Caller.newImage(manager.Current, false, DisplayTime);
        }
        #endregion

        #region Navigation
        public static int DisplayTime
        {
            get { return (int)MatConfigurationSection.GetSettings().DefaultImageTime.TotalMilliseconds; }
        }

        public void NextImage()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MediaHub>();
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            context.Clients.newImage(manager.Next(), false, DisplayTime);
        }

        public void PreviousImage()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MediaHub>();
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            context.Clients.newImage(manager.Previous(), true, DisplayTime);
        }
        #endregion
    }
}