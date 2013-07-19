using System.Collections.Generic;
using System.Diagnostics;
using DropNet;
using DropNet.Models;
using Mat.Common;

namespace Mat.Sources.Dropbox
{
    public class DropboxMediaSource : UpdatingMediaSource
    {
        private readonly List<Media> _media;
        protected DropboxMediaSourceSettings Settings;
        protected DropNetClient Client;

        public DropboxMediaSource(DropboxMediaSourceSettings settings)
        {
            _media = new List<Media>();
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
                                                    var media = MediaFactory.CreateFromUrl(Settings.Id, response.Url);
                                                    NewMedia(media);
                                                    ((List<Media>)Media).Add(media);
                                                }, exception => Debug.WriteLine(exception));
        }

        public override IEnumerable<Media> Media
        {
            get { return _media; }
        }

        public override ISourceSettings SourceSettings
        {
            get { return Settings; }
            set { Settings = value as DropboxMediaSourceSettings; }
        }
    }
}