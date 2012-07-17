using System;

namespace Mat.Common
{
    /// <summary>
    /// An image source factory creates image sources from settings.
    /// </summary>
    public interface IImageSourceFactory
    {
        /// <summary>
        /// The alias used in configuration files.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Instantiates an image source.
        /// </summary>
        /// <param name="sourceSettings">The settings to use. Guaranteed to be of type SettingsType</param>
        /// <returns>An image source.</returns>
        IImageSource InstantiateImageSource(ISourceSettings sourceSettings);
        /// <summary>
        /// The type of the AbstractSettings subclass to be used for storing settings.
        /// </summary>
        Type SettingsType { get; }
    }
}
