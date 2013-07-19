using System.Collections.Generic;

namespace Mat.Common
{
    public interface IMediaSource
    {
        IEnumerable<Media> Media { get; }
        ISourceSettings SourceSettings { get; set; }
    }
}
