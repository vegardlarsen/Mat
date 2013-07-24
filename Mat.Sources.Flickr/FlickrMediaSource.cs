using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mat.Common;
using Mat.Sources.Flickr.Favorites;
using Mat.Sources.Flickr.Photostream;
using Mat.Sources.Flickr.Photoset;

namespace Mat.Sources.Flickr
{
    public class FlickrMediaSource : IUpdatableMediaSource
    {
        private FlickrMediaSourceSettings _sourceSettings;
        private readonly FlickrNet.Flickr _flickr;
        private readonly IList<IFlickrApiSource> _sources;

        private readonly Dictionary<Type, Func<Guid, FlickrNet.Flickr, IFlickrApiSourceSettings, IFlickrApiSource>> _factories = new Dictionary
            <Type, Func<Guid, FlickrNet.Flickr, IFlickrApiSourceSettings, IFlickrApiSource>>
            {
                { typeof(PhotostreamSettings), (sourceId, flickr, settings) => new Photostream.Photostream(sourceId, flickr, settings) },
                { typeof(PhotosetSettings), (sourceId, flickr, settings) => new Photoset.Photoset(sourceId, flickr, settings) },
                { typeof(FavoritesSettings), (sourceId, flickr, settings) => new Favorites.Favorites(sourceId, flickr, settings)}
            };

        public FlickrMediaSource(FlickrMediaSourceSettings sourceSettings)
        {
            _sourceSettings = sourceSettings;
            _flickr = new FlickrNet.Flickr(_sourceSettings.ApiKey, _sourceSettings.SharedSecret);
            _sources = _sourceSettings.Sources
                .OfType<IFlickrApiSourceSettings>()
                .Select(s => _factories[s.GetType()](_sourceSettings.Id, _flickr, s))
                .ToList();
        }

        public IEnumerable<Media> Media
        {
            get { return _sources.SelectMany(s => s.Media).AsEnumerable(); }
        }

        public ISourceSettings SourceSettings
        {
            get { return _sourceSettings; }
            set { _sourceSettings = (FlickrMediaSourceSettings)value; }
        }

        public async Task UpdateAsync()
        {
            foreach (var s in _sources)
            {
                await s.UpdateAsync();
            }
        }
    }
}
