using System;
using Mat.Common;

namespace Mat.Sources.Static
{
    public class StaticMediaSourceFactory : IMediaSourceFactory
    {
        public string Alias
        {
            get { return "static"; }
        }

        public IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, string dataFolder)
        {
            return new StaticMediaSource(sourceSettings as StaticMediaSourceSettings);
        }

        public Type SettingsType
        {
            get { return typeof (StaticMediaSourceSettings); }
        }
    }
}
