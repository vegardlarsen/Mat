using System;
using Mat.Common;

namespace Mat.Sources.Dropbox
{
    public class DropboxMediaSourceFactory : IMediaSourceFactory
    {
        public string Alias
        {
            get { return "dropbox"; }
        }

        public IMediaSource InstantiateMediaSource(ISourceSettings sourceSettings, String folder)
        {
            var settings = sourceSettings as DropboxMediaSourceSettings;
            var source = settings.Local 
                ? new DropboxLocalMediaSource(settings, folder) 
                : new DropboxMediaSource(settings);

            source.Read();
            return source;
        }

        public Type SettingsType
        {
            get { return typeof (DropboxMediaSourceSettings); }
        }
    }
}
