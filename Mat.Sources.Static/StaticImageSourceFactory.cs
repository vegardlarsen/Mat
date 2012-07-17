using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mat.Common;

namespace Mat.Sources.Static
{
    public class StaticImageSourceFactory : IImageSourceFactory
    {
        public string Alias
        {
            get { return "static"; }
        }

        public IImageSource InstantiateImageSource(ISourceSettings sourceSettings)
        {
            return new StaticImageSource(sourceSettings as StaticImageSourceSettings);
        }

        public Type SettingsType
        {
            get { return typeof (StaticImageSourceSettings); }
        }
    }
}
