using System.Collections.Generic;

namespace Mat.Common
{
    public abstract class UpdatingImageSource : IImageSource
    {
        public abstract IEnumerable<Image> Images { get; }
        public abstract ISourceSettings SourceSettings { get; set; }

        protected void NewImage(Image image)
        {
            foreach (var queue in QueueManagerFactory.AllQueues)
            {
                queue.NewImage(image);
            }
        }

        protected void RemoveImage(Image image)
        {
            foreach (var queue in QueueManagerFactory.AllQueues)
            {
                queue.RemoveImage(image);
            }
        }
    }
}