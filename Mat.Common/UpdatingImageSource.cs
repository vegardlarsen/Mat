using System;
using System.Collections.Generic;
using Mat.Common;

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
    }
}