using System.Configuration;
using Mat.Common;

namespace Mat.Sources.FlickrFeed
{
    public class FlickrFeedSourceSettings : AbstractSourceSettings
    {
        [ConfigurationProperty("href", IsRequired = true)]
        public string FeedUrl
        {
            get { return (string)base["href"]; }
            set { base["href"] = value; }
        }
    }
}
