using System;
using System.Runtime.Serialization;

namespace Mat.Common
{
    [DataContract]
    public class Image
    {
        public Image(Guid sourceId)
        {
            SourceId = sourceId;
        }

        [DataMember(Name = "url")]
        public virtual String Url { get; set; }

        /// <summary>
        /// The title of the image, if known.
        /// 
        /// Set to null if the title is non-descriptive.
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false, IsRequired = false)]
        public virtual String Title { get; set; }

        /// <summary>
        /// The image's author, if known.
        /// </summary>
        [DataMember(Name = "author", EmitDefaultValue = false, IsRequired = false)]
        public virtual String Author { get; set; }

        /// <summary>
        /// Identifier for the source.
        /// </summary>
        public virtual Guid SourceId { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is Image)
            {
                var image = obj as Image;
                return image.Url == Url && image.SourceId == SourceId;
            }
            return base.Equals(obj);
        }
    }
}