using System.Configuration;
using System.Web.Configuration;

namespace Mat
{
    public class MatConfigurationSection : ConfigurationSection
    {
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