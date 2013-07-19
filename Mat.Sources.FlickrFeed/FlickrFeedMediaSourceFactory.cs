using System;
using Mat.Common;

namespace Mat.Sources.FlickrFeed
{
    internal class FlickrFeedMediaSourceFactory : IMediaSourceFactory
    {
        public string Alias
        {
            get { return "flickrFeed"; }
        }

        public IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, string storageDirectory)
        {
            var source = new FlickrFeedMediaSource(sourceSettings);
            source.UpdateAsync().Wait();
            return source;
        }

        public Type SettingsType
        {
            get { return typeof (FlickrFeedSourceSettings); }
        }
    }
}
