using System;
using System.Runtime.Serialization;
using System.Web;

namespace Mat.Common
{
    /// <summary>
    /// If your class self-hosts, you need to provide an additional "path"
    /// for your image.
    /// 
    /// The path will be passed to the LocalImageController, which serves
    /// the image based on the path.
    /// </summary>
    [DataContract]
    public class LocalMedia : Media
    {
        public LocalMedia(String path, Guid sourceId)
            : base (sourceId)
        {
            Path = path;
        }

        public String Path { get; private set; }

        /// <summary>
        /// Overridden to provide default route.
        /// </summary>
        public override String Url
        {
            get
            {
                return String.Format("/LocalMedia/?source={0}&path={1}",
                                     HttpUtility.UrlEncode(SourceId.ToString()),
                                     HttpUtility.UrlEncode(Path));
            }
            set { }
        }
    }
}