using System;
using System.Configuration;

namespace Mat.Sources.Static
{
    public class StaticMediaSourceLocation : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public String Path
        {
            get
            {
                return (string)base["path"];
            }
            set
            {
                base["path"] = value;
            }
        }

        [ConfigurationProperty("cache", IsRequired = false, DefaultValue = false)]
        public bool Cache { get; set; }
    }
}
