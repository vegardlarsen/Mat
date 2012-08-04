using System;
using System.Runtime.Serialization;

namespace Mat.Common
{
    public enum MediaType
    {
        Image = 0,
        Video = 1,
        Html = 2
    }

    public class Media
    {
        public Media(Guid source)
            : this()
        {
            SourceId = source;
        }

        public Media()
        {
            
        }

        /// <summary>
        /// Public URL that can be used to point to this media.
        /// </summary>
        [DataMember(Name = "url")]
        public virtual String Url { get; set; }

        /// <summary>
        /// Identifier for the source.
        /// </summary>
        public virtual Guid SourceId { get; set; }

        public virtual MediaType Type { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is Media)
            {
                var image = obj as Media;
                return image.Url == Url && image.SourceId == SourceId;
            }
            return base.Equals(obj);
        }
    }
}