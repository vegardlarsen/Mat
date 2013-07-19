using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mat.Common;

namespace Mat.Sources.Local
{
    public class LocalMediaSource : UpdatingMediaSource, ISelfHostedSource, IDisposable
    {
        private readonly HashSet<String> _extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                                                  {
                                                      ".jpeg",
                                                      ".jpg",
                                                      ".png"
                                                  };
        private readonly FileSystemWatcher _watcher = new FileSystemWatcher();

        public LocalMediaSource(ISourceSettings sourceSettings)
        {
            SourceSettings = sourceSettings;
            _watcher.Created += (sender, args) => NewMedia(new LocalMedia(args.FullPath, SourceSettings.Id));
            _watcher.Deleted += (sender, args) => RemoveMedia(new LocalMedia(args.FullPath, SourceSettings.Id));
            _watcher.Renamed += (sender, args) =>
                                    {
                                        RemoveMedia(new LocalMedia(args.OldFullPath, SourceSettings.Id));
                                        NewMedia(new LocalMedia(args.FullPath, SourceSettings.Id));
                                    };
        }

        public override IEnumerable<Media> Media
        {
            get
            {
                if (_sourceSettings.Path == null) return new List<Media>();
                return Directory.EnumerateFiles(_sourceSettings.Path, "*.*", SearchOption.AllDirectories)
                  .Where(path => _extensions.Contains(Path.GetExtension(path)))
                  .Select(f => new LocalMedia(f, SourceSettings.Id));
            }
        }

        private LocalMediaSourceSettings _sourceSettings;
        public override sealed ISourceSettings SourceSettings
        {
            get { return _sourceSettings; }
            set
            {
                if (!(value is LocalMediaSourceSettings)) return;
                
                _sourceSettings = value as LocalMediaSourceSettings;

                _watcher.EnableRaisingEvents = false;

                if (_sourceSettings == null || _sourceSettings.Path == null) return;
                
               _watcher.Path = _sourceSettings.Path;
                _watcher.EnableRaisingEvents = true;
            }
        }

        public Stream GetImageStream(string path)
        {
            if (!path.StartsWith(_sourceSettings.Path)) throw new UnauthorizedAccessException();

            return File.Open(path, FileMode.Open, FileAccess.Read);
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}