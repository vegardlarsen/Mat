using System;
using System.Collections.Generic;
using FlickrNet;

namespace Mat.Sources.Flickr.Photostream
{
    public class Photostream : FlickrApiSourceBase<PhotostreamSettings>
    {
        public Photostream(Guid sourceId, FlickrNet.Flickr flickr, IFlickrApiSourceSettings settings) 
            : base(sourceId, flickr, settings)
        {
        }

        protected override IEnumerable<Photo> GetForPage(int pageNumber, int perPage)
        {
            return Flickr.PeopleGetPublicPhotos(Settings.UserId, pageNumber, perPage, SafetyLevel.None, 
                PhotoSearchExtras.MediumUrl | PhotoSearchExtras.LargeUrl | PhotoSearchExtras.OriginalUrl);
        }
    }
}