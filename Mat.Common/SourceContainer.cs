using System.Collections.Generic;
using System.Linq;

namespace Mat.Common
{
    /// <summary>
    /// Contains instances of the running sources. Singleton.
    /// </summary>
    public class SourceContainer
    {
        private SourceContainer(IEnumerable<ISourceSettings> settings)
        {
            var locator = SourceLocator.GetInstance();

            _sources.AddRange(settings.Select(locator.InstantiateFromSettings));
        }

        private readonly List<IImageSource> _sources = new List<IImageSource>();

        public IList<IImageSource> Sources
        {
            get { return _sources; }
        }

        private static SourceContainer _instance;
        /// <summary>
        /// Singleton instantiator.
        /// </summary>
        public static SourceContainer CreateInstanceIfNotExists(IEnumerable<ISourceSettings> settings)
        {
            return _instance ?? (_instance = new SourceContainer(settings));
        }

        /// <summary>
        /// Singleton accessor.
        /// </summary>
        /// <returns></returns>
        public static SourceContainer GetInstance()
        {
            return _instance;
        }
    }
}