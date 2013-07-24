using System.Configuration;

namespace Mat.Sources.Flickr.Photostream
{
    public class PhotostreamSettings : FlickrSettingsBase
    {
        [ConfigurationProperty("userId", IsRequired = true)]
        public string UserId
        {
            get { return (string)base["userId"]; }
            set { base["userId"] = value; }
        }
    }
}