using System.Collections.Generic;

namespace Mat.Common
{
    public abstract class UpdatingMediaSource : IMediaSource
    {
        public abstract IEnumerable<Media> Media { get; }
        public abstract ISourceSettings SourceSettings { get; set; }

        protected void NewMedia(Media media)
        {
            foreach (var queue in QueueManagerFactory.AllQueues)
            {
                queue.NewMedia(media);
            }
        }

        protected void RemoveMedia(Media media)
        {
            foreach (var queue in QueueManagerFactory.AllQueues)
            {
                queue.RemoveMedia(media);
            }
        }
    }
}