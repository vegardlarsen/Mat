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
    public abstract class FlickrApiSourceBase<T> : IFlickrApiSource
        where T: IFlickrApiSourceSettings
    {
        private readonly Guid _sourceId;
        private readonly ICollection<Media> _media = new Collection<Media>();
        private int _page;
        private bool _sourceEmpty = false;

        private const int PerPage = 100;

        protected readonly FlickrNet.Flickr Flickr;
        protected readonly T Settings;

        internal FlickrApiSourceBase(Guid sourceId, FlickrNet.Flickr flickr, IFlickrApiSourceSettings settings)
        {
            _sourceId = sourceId;
            Flickr = flickr;
            Settings = (T) settings;
        }

        public IEnumerable<Media> Media
        {
            get { return _media; }
        }

        private Media CreateMedia(Photo p)
        {
            var url = p.MediumUrl;
            if (Settings.PreferredSize >= FlickrSize.Large && p.DoesLargeExist)
            {
                url = p.LargeUrl;
            }
            if (Settings.PreferredSize >= FlickrSize.Original && !String.IsNullOrEmpty(p.OriginalUrl))
            {
                url = p.OriginalUrl;
            }
            return MediaFactory.CreateFromUrl(_sourceId, url);
        }


        public Task UpdateAsync()
        {
            return Task.Factory.StartNew(() =>
                {
                    if (_sourceEmpty) return;

                    var photos = GetForPage(_page++, PerPage).Select(CreateMedia);
                    if (photos.Count() < PerPage)
                    {
                        _sourceEmpty = true;
                    }
                    _media.AddRange(photos);
                });
        }

        protected abstract IEnumerable<Photo> GetForPage(int pageNumber, int perPage);
    }
}