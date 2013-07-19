using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using Mat.Common;

namespace Mat.Controllers
{
    [DataContract]
    public class MediaRequest
    {
        [DataMember(Name = "source")]
        public Guid Source { get; set; }

        [DataMember(Name = "path")]
        public String Path { get; set; }
    }

    /// <summary>
    /// Controller that serves up locally cached image requests over HTTP.
    /// </summary>
    public class LocalMediaController : Controller
    {
        public ActionResult Index(MediaRequest request)
        {
            var source = SourceContainer.GetInstance().Sources.First(s => s.SourceSettings.Id == request.Source);
            if (!(source is ISelfHostedSource)) throw new UnauthorizedAccessException();

            var stream = (source as ISelfHostedSource).GetImageStream(request.Path);
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0, 0));
            Response.Cache.SetSlidingExpiration(true);
            // TODO: fix MIME type
            return new FileStreamResult(stream, "image/jpeg");
        }
    }
}
