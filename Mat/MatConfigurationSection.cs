using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.Configuration;

namespace Mat
{
    public class MatConfigurationSection : ConfigurationSection
    {
        #region Settings
        [TypeConverter(typeof(TimeSpanConverter))]
        [ConfigurationProperty("displayTime", DefaultValue = "0:05:00")]
        public TimeSpan DefaultImageTime
        {
            get { return (TimeSpan)base["displayTime"]; }
            set { base["displayTime"] = value; }
        }
        #endregion

        [ConfigurationProperty("sources", IsDefaultCollection = true, IsRequired = false, IsKey = false)]
        public MatSourceCollection Sources
        {
            get { return (MatSourceCollection) base["sources"]; }
            set { base["sources"] = value; }
        }

        public static MatConfigurationSection GetSettings()
        {
            return (WebConfigurationManager.GetSection("mat") as MatConfigurationSection) ?? new MatConfigurationSection();
        }
    }
}