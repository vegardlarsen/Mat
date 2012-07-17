using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mat.Common
{
    public static class ImageExtensions
    {
        public static int Ordering(this Image image)
        {
            var code =  image.SourceId.ToByteArray().Aggregate("", (current, b) => current + b);
            code += image.Url;
            var sha = new SHA1CryptoServiceProvider();

            var hash = sha.ComputeHash(Encoding.Default.GetBytes(code));

            return BitConverter.ToInt32(hash, 0);
        }
    }
}
