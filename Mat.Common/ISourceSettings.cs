using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

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
