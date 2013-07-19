using System.Configuration;
using Mat.Common;

namespace Mat.Sources.Flickr
{
    public class FlickrMediaSourceSettings : AbstractSourceSettings
    {
        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string ApiKey
        {
            get { return (string)base["apiKey"]; }
            set { base["apiKey"] = value; }
        }

        [ConfigurationProperty("sharedSecret", IsRequired = true)]
        public string SharedSecret
        {
            get { return (string)base["sharedSecret"]; }
            set { base["sharedSecret"] = value; }
        }

        [ConfigurationProperty("sources", IsDefaultCollection = true, IsRequired = false, IsKey = false)]
        public FlickrSourceCollection Sources
        {
            get { return (FlickrSourceCollection)base["sources"]; }
            set { base["sources"] = value; }
        }
    }
}