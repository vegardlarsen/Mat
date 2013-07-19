using System;
using System.Configuration;

namespace Mat.Common
{
    /// <summary>
    /// Base class for all source settings.
    /// </summary>
    public abstract class AbstractSourceSettings : ConfigurationElement, ISourceSettings
    {
        protected AbstractSourceSettings()
        {
            Id = Guid.NewGuid();
        }

        [ConfigurationProperty("id")]
        public Guid Id
        {
            get { return (Guid) base["id"]; }
            set { base["id"] = value; }
        }
    }
}