using System;
using System.Collections.Generic;
using FlickrNet;

namespace Mat.Sources.Flickr.Photoset
{
    public class Photoset : FlickrApiSourceBase<PhotosetSettings>
    {
        public Photoset(Guid sourceId, FlickrNet.Flickr flickr, IFlickrApiSourceSettings settings) 
            : base(sourceId, flickr, settings)
        {
        }

        protected override IEnumerable<Photo> GetForPage(int pageNumber, int perPage)
        {
            return Flickr.PhotosetsGetPhotos(Settings.PhotosetId, 
                PhotoSearchExtras.MediumUrl | PhotoSearchExtras.LargeUrl | PhotoSearchExtras.OriginalUrl, 
                pageNumber, perPage);
        }
    }
}