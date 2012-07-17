using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mat.Common;

namespace Mat.Sources.Static
{
    public class StaticImageSource : IImageSource
    {
        public StaticImageSource(StaticImageSourceSettings sourceSettings)
        {
            _sourceSettings = sourceSettings;
        }

        public IEnumerable<Image> Images
        {
            get
            {
                return from object i in _sourceSettings
                       select i as StaticImageSourceLocation
                       into location
                       select new Image(SourceSettings.Id)
                                  {
                                      Url = location.Path
                                  };
            }
        }

        private StaticImageSourceSettings _sourceSettings;

        public ISourceSettings SourceSettings
        {
            get { return _sourceSettings; }
            set
            {
                if (!(value is StaticImageSourceSettings)) return;

                _sourceSettings = value as StaticImageSourceSettings;
            }
        }
    }
}
