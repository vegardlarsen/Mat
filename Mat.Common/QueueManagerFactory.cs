using System.Collections.Generic;

namespace Mat.Common
{
    public static class QueueManagerFactory
    {
        private static IQueueManager _instance;
        public static IQueueManager FromClient(string identifier)
        {
            return _instance ?? (_instance = new CommonQueueManager());
        }

        public static IEnumerable<IQueueManager> AllQueues
        {
            get { yield return _instance; }
        }
    }
}
