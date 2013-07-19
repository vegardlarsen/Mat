using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FlickrNet;
using Mat.Common;
using Mat.Common.Extensions;

namespace Mat.Sources.Flickr
{
    public class Photostream : IFlickrApiSource
    {
        private readonly Guid _sourceId;
        private readonly FlickrNet.Flickr _flickr;
        private readonly PhotostreamSettings _settings;
        private readonly ICollection<Media> _media = new Collection<Media>();

        public Photostream(Guid sourceId, FlickrNet.Flickr flickr, IFlickrApiSourceSettings settings)
        {
            _sourceId = sourceId;
            _flickr = flickr;
            _settings = (PhotostreamSettings) settings;
        }

        public IEnumerable<Media> Media
        {
            get { return _media; }
        }

        public Task UpdateAsync()
        {
            return Task.Factory.StartNew(() =>
                {
                    var photos = _flickr.PeopleGetPublicPhotos(_settings.UserId, 0, 100, SafetyLevel.Safe, PhotoSearchExtras.OriginalUrl);
                    var media = photos.Select(p => MediaFactory.CreateFromUrl(_sourceId, p.LargeUrl)).ToList();
                    _media.AddRange(media);
                    var a = 0;
                });
        }
    }
}