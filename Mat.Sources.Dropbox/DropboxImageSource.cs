using System.Collections.Generic;
using System.Diagnostics;
using DropNet;
using DropNet.Models;
using Mat.Common;

namespace Mat.Sources.Dropbox
{
    public class DropboxImageSource : UpdatingImageSource
    {
        private readonly List<Image> _images;
        protected DropboxImageSourceSettings Settings;
        protected DropNetClient Client;

        public DropboxImageSource(DropboxImageSourceSettings settings)
        {
            _images = new List<Image>();
            Settings = settings;

            Client = new DropNetClient(Settings.ApplicationKey, Settings.ApplicationSecret, Settings.UserToken,
                            Settings.UserSecret) { UseSandbox = Settings.Sandbox };
        }

        internal void Read()
        {
            ReadFolder(Settings.Path);
        }

        protected void ParseMetadata(MetaData data)
        {
            if (data.Is_Dir)
            {
                if (data.Contents == null && Settings.Recursive)
                {
                    ReadFolder(data.Path);
                }
                else if (data.Contents != null)
                {
                    foreach (var d in data.Contents)
                    {
                        ParseMetadata(d);
                    }
                }
            }
            else
            {
                if (!MediaFactory.IsPathMedia(data.Path)) return;
                ParseImageMetadata(data);
            }
        }

        protected virtual void ReadFolder(string remotePath)
        {
            Client.GetMetaDataAsync(remotePath, ParseMetadata, exception => Debug.WriteLine(exception));
        }

        protected virtual void ParseImageMetadata(MetaData data)
        {
            Client.GetMediaAsync(data.Path, response =>
                                                {
                                                    var image = new Image(Settings.Id)
                                                    {
                                                        Url = response.Url
                                                    };
                                                    NewImage(image);
                                                    ((List<Image>)Images).Add(image);
                                                }, exception => Debug.WriteLine(exception));
        }

        public override IEnumerable<Image> Images
        {
            get { return _images; }
        }

        public override ISourceSettings SourceSettings
        {
            get { return Settings; }
            set { Settings = value as DropboxImageSourceSettings; }
        }
    }
}