using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DropNet.Exceptions;
using DropNet.Models;
using Mat.Common;
using RestSharp;

namespace Mat.Sources.Dropbox
{
    public class DropboxLocalMediaSource : DropboxMediaSource, ISelfHostedSource
    {
        private readonly string _folder;

        public DropboxLocalMediaSource(DropboxMediaSourceSettings dropboxMediaSourceSettings, String folder) : base(dropboxMediaSourceSettings)
        {
            // store our files inside user-specific folder
            _folder = Path.Combine(folder, Settings.UserToken);
            Directory.CreateDirectory(_folder);

            // load images we already have downloaded
            ((List<Media>)Media).AddRange(Directory.EnumerateFiles(_folder, "*.*",
                                                      Settings.Recursive
                                                          ? SearchOption.AllDirectories
                                                          : SearchOption.TopDirectoryOnly)
                                 .Where(MediaFactory.IsPathMedia)
                                 .Select(p => new LocalMedia(p, Settings.Id)));
        }

        public override sealed IEnumerable<Media> Media
        {
            get { return base.Media; }
        }

        private string LocalPathFromRemotePath(string remotePath)
        {
            return Path.Combine(_folder, remotePath.Substring(1));
        }

        private string ReadLocalHash(string remotePath)
        {
            try
            {
                return File.ReadAllText(Path.Combine(LocalPathFromRemotePath(remotePath), ".hash"));
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        private void WriteLocalHash(string remotePath, string hash)
        {
            File.WriteAllText(Path.Combine(LocalPathFromRemotePath(remotePath), ".hash"), hash);
        }

        protected override void ReadFolder(string remotePath)
        {
            var hash = ReadLocalHash(remotePath);
            var handler = new Action<MetaData>(data =>
                                    {
                                        WriteLocalHash(remotePath, data.Hash);
                                        ParseMetadata(data);
                                    });
            var exceptionHandler = new Action<DropboxException>(exception => Debug.WriteLine(exception.ToString()));
            if (hash == null)
            {
                Client.GetMetaDataAsync(remotePath, handler, exceptionHandler);
            }
            else
            {
                Client.GetMetaDataAsync(remotePath, hash, handler, exceptionHandler);
            }
        }

        protected override void ParseImageMetadata(MetaData data)
        {
            var localPath = LocalPathFromRemotePath(data.Path);
            if (File.Exists(localPath)) return;
            Client.GetFileAsync(data.Path,
                     delegate(IRestResponse response)
                     {
                         
                         using (var fs = new FileStream(localPath, FileMode.CreateNew, FileAccess.Write))
                         {
                             fs.Write(response.RawBytes, 0, response.RawBytes.Length);
                         }
                         var media = new LocalMedia(localPath, Settings.Id);
                         NewMedia(media);
                         ((List<Media>)Media).Add(media);
                     },
                     exception => Debug.WriteLine(exception));

        }

        public Stream GetImageStream(string path)
        {
            if (!path.StartsWith(_folder)) throw new UnauthorizedAccessException();

            return File.OpenRead(path);
        }
    }
}