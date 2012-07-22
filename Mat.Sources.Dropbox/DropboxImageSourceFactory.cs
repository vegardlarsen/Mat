using System;
using Mat.Common;

namespace Mat.Sources.Dropbox
{
    public class DropboxImageSourceFactory : IImageSourceFactory
    {
        public string Alias
        {
            get { return "dropbox"; }
        }

        public IImageSource InstantiateImageSource(ISourceSettings sourceSettings, String folder)
        {
            var settings = sourceSettings as DropboxImageSourceSettings;
            var source = settings.Local 
                ? new DropboxLocalImageSource(settings, folder) 
                : new DropboxImageSource(settings);

            source.Read();
            return source;
        }

        public Type SettingsType
        {
            get { return typeof (DropboxImageSourceSettings); }
        }
    }
}
