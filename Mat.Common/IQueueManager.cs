using System.Collections.Generic;

namespace Mat.Common
{
    public interface IQueueManager
    {
        IEnumerable<Media> Queue { get; }
        IEnumerable<Media> History { get; }
        
        /// <summary>
        /// Jumps to the next image immediately.
        /// </summary>
        Media Next();
        /// <summary>
        /// Jumps to the previous image immediately.
        /// </summary>
        Media Previous();

        Media Current { get; }

        /// <summary>
        /// Adds a new image to the queue.
        /// </summary>
        /// <param name="media">The image to add.</param>
        void NewMedia(Media media);

        /// <summary>
        /// Removes an image from the queue.
        /// </summary>
        /// <param name="media">The image to remove.</param>
        void RemoveMedia(Media media);
    }
}
