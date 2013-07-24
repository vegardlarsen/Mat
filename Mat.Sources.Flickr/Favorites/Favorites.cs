using System;
using System.Collections.Generic;
using FlickrNet;

namespace Mat.Sources.Flickr.Favorites
{
    public class Favorites : FlickrApiSourceBase<FavoritesSettings>
    {
        public Favorites(Guid sourceId, FlickrNet.Flickr flickr, IFlickrApiSourceSettings settings) 
            : base(sourceId, flickr, settings)
        {
        }

        protected override IEnumerable<Photo> GetForPage(int pageNumber, int perPage)
        {
            return Flickr.FavoritesGetPublicList(Settings.UserId, 
                Settings.MinimumDate.HasValue ? Settings.MinimumDate.Value : DateTime.MinValue,
                Settings.MaximumDate.HasValue ? Settings.MaximumDate.Value : DateTime.MinValue,
                PhotoSearchExtras.MediumUrl | PhotoSearchExtras.LargeUrl | PhotoSearchExtras.OriginalUrl, 
                pageNumber, perPage);
        }
    }
}