using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mat.Common
{
    /// <summary>
    /// Finds source types in assemblies. Singleton.
    /// </summary>
    public class SourceLocator
    {
        private SourceLocator() { }

        private static SourceLocator _instance;
        public static SourceLocator GetInstance()
        {
            return _instance ?? (_instance = new SourceLocator());
        }

        /// <summary>
        /// Used to prevent trying to load the same assembly twice.
        /// </summary>
        private readonly List<string> _loadedFiles = new List<string>();
        /// <summary>
        /// Used to prevent trying to scan the same folder twice.
        /// </summary>
        private readonly List<string> _scannedFolders = new List<string>();
        /// <summary>
        /// The individual factories and their corresponding alias (for use in configuration files).
        /// </summary>
        private readonly Dictionary<string, IImageSourceFactory> _factories = new Dictionary<string, IImageSourceFactory>();

        public void ScanFolder(string folder)
        {
            folder = Path.GetFullPath(folder);

            if (_scannedFolders.Contains(folder)) return;
            _scannedFolders.Add(folder);
            foreach (var file in Directory.EnumerateFiles(folder, "*.dll", SearchOption.AllDirectories))
            {
                AddSourcesFromFile(file);
            }
        }

        private void AddSourcesFromFile(string filename)
        {
            filename = Path.GetFullPath(filename);
            if (_loadedFiles.Contains(filename))
            {
                return;
            }

            _loadedFiles.Add(filename);
            try
            {
                var assembly = Assembly.LoadFrom(filename);
                foreach (var factory in assembly.GetTypes()
                    .Where(t => t.GetInterface("IImageSourceFactory") != null)
                    .Select(t => (IImageSourceFactory)Activator.CreateInstance(t)))
                {
                    _factories.Add(factory.Alias, factory);
                }
            }
            catch (BadImageFormatException) { }
        }

        /// <summary>
        /// Returns all the factories indexed by their alias.
        /// </summary>
        public IDictionary<string, IImageSourceFactory> Factories
        {
            get { return _factories; }
        }

        /// <summary>
        /// Instantiate using the factory from a given set of settings.
        /// </summary>
        /// <param name="sourceSettings">The settings to load.</param>
        /// <returns>Instance of image source</returns>
        public IImageSource InstantiateFromSettings(ISourceSettings sourceSettings)
        {
            var query = _factories.Values.Where(f => f.SettingsType == sourceSettings.GetType()).ToList();
            if (!query.Any()) throw new ArgumentException("Could not find image source that accepts this type");

            var factory = query.First();
            var folder = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), factory.Alias);
            Directory.CreateDirectory(folder);

            return factory.InstantiateImageSource(sourceSettings, folder);
        }
    }
}
