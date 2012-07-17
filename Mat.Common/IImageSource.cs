using System.Collections.Generic;

namespace Mat.Common
{
    public interface IImageSource
    {
        IEnumerable<Image> Images { get; }
        ISourceSettings SourceSettings { get; set; }
    }
}
