using System;
using Mat.Common;

namespace Mat.Sources.Local
{
    public class LocalMediaSourceFactory : IMediaSourceFactory
    {
        public string Alias
        {
            get { return "local"; }
        }

        public IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, string dataFolder)
        {
            return new LocalMediaSource(sourceSettings);
        }

        public Type SettingsType
        {
            get { return typeof (LocalMediaSourceSettings); }
        }
    }
}
