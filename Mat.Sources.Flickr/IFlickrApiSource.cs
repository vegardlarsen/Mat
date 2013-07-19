using System.Collections.Generic;
using System.Threading.Tasks;
using Mat.Common;

namespace Mat.Sources.Flickr
{
    interface IFlickrApiSource
    {
        IEnumerable<Media> Media { get; }
        Task UpdateAsync();
    }
}