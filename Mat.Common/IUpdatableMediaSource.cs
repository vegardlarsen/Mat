using System.Threading.Tasks;

namespace Mat.Common
{
    /// <summary>
    /// An updatabable media source.
    /// 
    /// An update is triggered when the end of the enumerable media is 
    /// reached. At this point, the media source can decide if it wants 
    /// to replace the Media list, or append to it.
    /// </summary>
    public interface IUpdatableMediaSource : IMediaSource
    {
        Task UpdateAsync();
    }
}