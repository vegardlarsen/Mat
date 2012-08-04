using System.Collections.Generic;
using Mat.Common;

namespace Mat.Common
{
    public interface IMediaSource
    {
        IEnumerable<Media> Media { get; }
        ISourceSettings SourceSettings { get; set; }
    }
}
