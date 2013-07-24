using System.Configuration;

namespace Mat.Sources.Flickr.Photoset
{
    public class PhotosetSettings : FlickrSettingsBase
    {
        [ConfigurationProperty("userId", IsRequired = true)]
        public string UserId
        {
            get { return (string)base["userId"]; }
            set { base["userId"] = value; }
        }

        [ConfigurationProperty("setId", IsRequired = true)]
        public string PhotosetId
        {
            get { return (string)base["setId"]; }
            set { base["setId"] = value; }
        }
    }
}