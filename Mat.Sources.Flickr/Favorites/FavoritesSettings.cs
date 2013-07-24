using System;
using System.Configuration;

namespace Mat.Sources.Flickr.Favorites
{
    public class FavoritesSettings : FlickrSettingsBase
    {
        [ConfigurationProperty("userId", IsRequired = true)]
        public string UserId
        {
            get { return (string)base["userId"]; }
            set { base["userId"] = value; }
        }

        [ConfigurationProperty("minDate", IsRequired = false)]
        public DateTime? MinimumDate
        {
            get { return (DateTime?) base["minDate"]; }
            set { base["minDate"] = value; }
        }

        [ConfigurationProperty("maxDate", IsRequired = false)]
        public DateTime? MaximumDate
        {
            get { return (DateTime?)base["maxDate"]; }
            set { base["maxDate"] = value; }
        }
    }
}