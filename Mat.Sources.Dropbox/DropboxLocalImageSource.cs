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
    public class DropboxLocalImageSource : DropboxImageSource, ISelfHostedSource
    {
        private readonly string _folder;

        public DropboxLocalImageSource(DropboxImageSourceSettings dropboxImageSourceSettings, String folder) : base(dropboxImageSourceSettings)
        {
            // store our files inside user-specific folder
            _folder = Path.Combine(folder, Settings.UserToken);
            Directory.CreateDirectory(_folder);

            // load images we already have downloaded
            ((List<Image>)Images).AddRange(Directory.EnumerateFiles(_folder, "*.*",
                                                      Settings.Recursive
                                                          ? SearchOption.AllDirectories
                                                          : SearchOption.TopDirectoryOnly)
                                 .Where(MediaFactory.IsPathMedia)
                                 .Select(p => new LocalImage(p, Settings.Id)));
        }

        public override sealed IEnumerable<Image> Images
        {
            get { return base.Images; }
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
                     delegate(RestResponse response)
                     {
                         
                         using (var fs = new FileStream(localPath, FileMode.CreateNew, FileAccess.Write))
                         {
                             fs.Write(response.RawBytes, 0, response.RawBytes.Length);
                         }
                         var image = new LocalImage(localPath, Settings.Id);
                         NewImage(image);
                         ((List<Image>)Images).Add(image);
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