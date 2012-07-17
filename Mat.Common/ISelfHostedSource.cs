using System;
using System.IO;

namespace Mat.Common
{
    /// <summary>
    /// A self-hosted source provides a stream of the resource.
    /// 
    /// The resource is then served by the local web server.
    /// </summary>
    public interface ISelfHostedSource : IImageSource
    {
        /// <summary>
        /// Returns a stream to the requested resource.
        /// </summary>
        /// <param name="path">"Path" to the image. Can also be an identifier if that works for the provider.</param>
        /// <returns>Request stream.</returns>
        Stream GetImageStream(String path);
    }
}