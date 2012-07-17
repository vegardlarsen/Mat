using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mat.Common;
using Mat.Helpers;

namespace Mat.Controllers
{
    public class ImagesController : ApiController
    {
        public IEnumerable<Image> Get()
        {
            return SourceContainer.GetInstance().Sources.First().Images;
        }
    }
}