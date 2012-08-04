using System;

namespace Mat.Common
{
    /// <summary>
    /// An image source factory creates image sources from settings.
    /// </summary>
    public interface IMediaSourceFactory
    {
        /// <summary>
        /// The alias used in configuration files.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Instantiates a media source.
        /// </summary>
        /// <param name="sourceSettings">The settings to use. Guaranteed to be of type SettingsType</param>
        /// <param name="storageDirectory">A folder where the source can store files it needs. The folder is common to all image sources of the same type, so create a subdirectory that you can find again and work inside it.</param>
        /// <returns>An image source.</returns>
        IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, String storageDirectory);
        /// <summary>
        /// The type of the AbstractSettings subclass to be used for storing settings.
        /// </summary>
        Type SettingsType { get; }
    }
}
