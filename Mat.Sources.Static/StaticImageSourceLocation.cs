using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Mat.Sources.Static
{
    public class StaticImageSourceLocation : ConfigurationElement
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
