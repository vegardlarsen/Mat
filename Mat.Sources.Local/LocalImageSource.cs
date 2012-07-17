using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Mat.Common;

namespace Mat.Sources.Local
{
    public class LocalImageSource : UpdatingImageSource, ISelfHostedSource
    {
        private readonly HashSet<String> _extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                                                  {
                                                      ".jpeg",
                                                      ".jpg",
                                                      ".png"
                                                  };
        private readonly FileSystemWatcher _watcher = new FileSystemWatcher();

        public LocalImageSource(ISourceSettings sourceSettings)
        {
            _watcher.Created += (sender, args) => NewImage(new LocalImage(args.FullPath, SourceSettings.Id));
            SourceSettings = sourceSettings;
        }

        public override IEnumerable<Image> Images
        {
            get
            {
                if (_sourceSettings.Path == null) return new List<Image>();
                return Directory.EnumerateFiles(_sourceSettings.Path, "*.*", SearchOption.AllDirectories)
                  .Where(path => _extensions.Contains(Path.GetExtension(path)))
                  .Select(f => new LocalImage(f, SourceSettings.Id));
            }
        }

        private LocalImageSourceSettings _sourceSettings;
        public override sealed ISourceSettings SourceSettings
        {
            get { return _sourceSettings; }
            set
            {
                if (!(value is LocalImageSourceSettings)) return;
                
                _sourceSettings = value as LocalImageSourceSettings;

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
    }
}