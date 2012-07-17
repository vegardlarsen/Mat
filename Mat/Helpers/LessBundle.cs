using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using dotless.Core;
using dotless.Core.configuration;

namespace Mat.Helpers
{
    public class LessBundle : IBundleTransform
    {
        public IEnumerable<String> CompiledFiles { get; set; }

        public void Process(BundleContext context, BundleResponse response)
        {
            var configuration = DotlessConfiguration.GetDefault();
            configuration.InlineCssFiles = true;
            var engine = new EngineFactory(configuration).GetEngine();
            var css = string.Empty;

            var files = response.Files.Where(f => f.Extension.ToLower() == ".less");
            if (CompiledFiles.Any())
            {
                files = files.Where(f => CompiledFiles.Contains(Path.GetFileName(f.FullName)));
            }

            foreach (var file in files)
            {
                var currentDir = Directory.GetCurrentDirectory();
                try
                {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(file.FullName));
                    var source = File.ReadAllText(file.FullName);
                    css += engine.TransformToCss(source, file.FullName);
                }
                finally
                {
                    Directory.SetCurrentDirectory(currentDir);
                }
            }

            response.Content = css;
            response.ContentType = "text/css";
            response.Cacheability = HttpCacheability.NoCache;
        }
    }
}