using System.Collections.Generic;

namespace Mat.Common
{
    public class MediaEqualityComparer : IEqualityComparer<Media>
    {
        public bool Equals(Media x, Media y)
        {
            return x.SourceId == y.SourceId
                   && x.Type == y.Type
                   && x.Url == y.Url;
        }

        public int GetHashCode(Media obj)
        {
            return obj.SourceId.GetHashCode() + obj.Type.GetHashCode() + obj.Url.GetHashCode();
        }
    }
}
