using System.Configuration;

namespace Mat.Sources.Flickr
{
    public class PhotostreamSettings : ConfigurationElement, IFlickrApiSourceSettings
    {
        [ConfigurationProperty("id")]
        public string UserId
        {
            get { return (string)base["id"]; }
            set { base["id"] = value; }
        }
    }
}