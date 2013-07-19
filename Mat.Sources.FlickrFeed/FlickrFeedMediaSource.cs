using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using Mat.Common;

namespace Mat.Sources.FlickrFeed
{
    public class FlickrFeedMediaSource : IMediaSource, IUpdatableMediaSource
    {
        private FlickrFeedSourceSettings _sourceSettings;

        public FlickrFeedMediaSource(ISourceSettings sourceSettings)
        {
            _sourceSettings = (FlickrFeedSourceSettings) sourceSettings;
            _media = new List<Media>();
        }

        private IEnumerable<Media> _media;

        public IEnumerable<Media> Media 
        { 
            get { return _media; }
        }


        public ISourceSettings SourceSettings
        {
            get { return _sourceSettings; }
            set { _sourceSettings = (FlickrFeedSourceSettings) value; }
        }

        public Task UpdateAsync()
        {
            return Task.Factory.StartNew(() =>
                {
                    var feed = SyndicationFeed.Load(XmlReader.Create(_sourceSettings.FeedUrl));
                    var imageEntries = feed.Items.Where(e => e.Links.Any(l => l.MediaType.StartsWith("image")));
                    var images = imageEntries.Select(i => MediaFactory.CreateFromUrl(_sourceSettings.Id,
                            i.Links.FirstOrDefault(l => l.MediaType.StartsWith("image")).Uri.ToString()));
                    _media = _media.Union(images);
                    _media = _media.Distinct(new MediaEqualityComparer());
                });
        }
    }
}
