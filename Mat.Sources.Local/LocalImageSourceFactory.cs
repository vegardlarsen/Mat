using System;
using Mat.Common;

namespace Mat.Sources.Local
{
    public class LocalImageSourceFactory : IImageSourceFactory
    {
        public string Alias
        {
            get { return "local"; }
        }

        public IImageSource InstantiateImageSource(ISourceSettings sourceSettings, string dataFolder)
        {
            return new LocalImageSource(sourceSettings);
        }

        public Type SettingsType
        {
            get { return typeof (LocalImageSourceSettings); }
        }
    }
}
