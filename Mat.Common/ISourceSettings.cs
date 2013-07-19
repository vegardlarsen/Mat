using System;
using System.Configuration;

namespace Mat.Common
{
    public interface ISourceSettings
    {
        /// <summary>
        /// An identifier for the image source (that is not persisted across restarts unless provided in the configuration).
        /// 
        /// The identifier is different for each instance of the same source.
        /// </summary>
        [ConfigurationProperty("id")]
        Guid Id { get; set; }
    }
}
