using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Mat.Common;
using SignalR.Hubs;

namespace Mat.Helpers
{
    public class ImageHub : Hub, IConnected
    {
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
    }
}