using System.Collections.Generic;
using System.Linq;
using Mat.Common;

namespace Mat.Sources.Static
{
    public class StaticMediaSource : IMediaSource
    {
        public StaticMediaSource(StaticMediaSourceSettings sourceSettings)
        {
            _sourceSettings = sourceSettings;
        }

        public IEnumerable<Media> Media
        {
            get
            {
                return from object i in _sourceSettings
                       select i as StaticMediaSourceLocation
                       into location
                       select MediaFactory.CreateFromUrl(SourceSettings.Id, location.Path);
            }
        }

        private StaticMediaSourceSettings _sourceSettings;

        public ISourceSettings SourceSettings
        {
            get { return _sourceSettings; }
            set
            {
                if (!(value is StaticMediaSourceSettings)) return;

                _sourceSettings = value as StaticMediaSourceSettings;
            }
        }
    }
}
