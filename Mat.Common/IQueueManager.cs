using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mat.Common
{
    public interface IQueueManager
    {
        IEnumerable<Image> Queue { get; }
        IEnumerable<Image> History { get; }
        
        /// <summary>
        /// Jumps to the next image immediately.
        /// </summary>
        Image Next();
        /// <summary>
        /// Jumps to the previous image immediately.
        /// </summary>
        Image Previous();

        Image Current { get; }

        /// <summary>
        /// Adds a new image to the queue.
        /// </summary>
        /// <param name="image">The image to add.</param>
        void NewImage(Image image);
    }
}
