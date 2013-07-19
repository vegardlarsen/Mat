﻿using System;
using Mat.Common;

namespace Mat.Sources.Flickr
{
    public class FlickrMediaSourceFactory : IMediaSourceFactory
    {
        public string Alias { get { return "flickr"; } }
        public IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, string storageDirectory)
        {
            var flickr = new FlickrMediaSource((FlickrMediaSourceSettings) sourceSettings);
            var task = flickr.UpdateAsync();
            task.Wait();
            return flickr;
        }

        public Type SettingsType 
        {
            get { return typeof (FlickrMediaSourceSettings); }
        }
    }
}