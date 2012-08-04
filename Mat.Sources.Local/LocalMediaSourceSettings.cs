using System;
using System.Configuration;
using System.IO;
using Mat.Common;

namespace Mat.Sources.Local
{
    public class LocalMediaSourceSettings : AbstractSourceSettings
    {
        /// <summary>
        /// The path to load images from.
        /// </summary>
        [ConfigurationProperty("path", IsRequired = true)]
        public String Path
        {
            get 
            { 
                return (string) base["path"];
            }
            set
            {
                if (!Directory.Exists(value)) throw new DirectoryNotFoundException();
                base["path"] = value;
            }
        }
    }
}
