using System;
using Mat.Common;

namespace Mat.Sources.FlickrFeed
{
    internal class FlickrFeedMediaSourceFactory : IMediaSourceFactory
    {
        public string Alias
        {
            get { return "flickr"; }
        }

        public IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, string storageDirectory)
        {
            return new FlickrFeedMediaSource(sourceSettings);
        }

        public Type SettingsType
        {
            get { return typeof (FlickrFeedSourceSettings); }
        }
    }
}
