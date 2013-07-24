using System.Configuration;

namespace Mat.Sources.Flickr
{
    public abstract class FlickrSettingsBase : ConfigurationElement, IFlickrApiSourceSettings
    {
        [ConfigurationProperty("preferredSize", IsRequired = false, DefaultValue = FlickrSize.Original)]
        public FlickrSize PreferredSize
        {
            get { return (FlickrSize)base["preferredSize"]; }
            set { base["preferredSize"] = value; }
        }
    }
}