using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            return Caller.newImage(manager.Current);
        }

        public Task Reconnect(IEnumerable<string> groups)
        {
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            return Caller.newImage(manager.Current);
        }
        #endregion

        #region Navigation
        public void NextImage()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MediaHub>();
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            context.Clients.newImage(manager.Next());
        }

        public void PreviousImage()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MediaHub>();
            var manager = QueueManagerFactory.FromClient(Context.ConnectionId);
            context.Clients.newImage(manager.Previous(), true);
        }
        #endregion
    }
}