using System.Configuration;
using Mat.Common;

namespace Mat.Sources.Dropbox
{
    public class DropboxMediaSourceSettings : AbstractSourceSettings
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string ApplicationKey
        {
            get { return (string)base["key"]; }
            set { base["key"] = value; }
        }

        [ConfigurationProperty("secret", IsRequired = true)]
        public string ApplicationSecret
        {
            get { return (string) base["secret"]; }
            set { base["secret"] = value; }
        }

        [ConfigurationProperty("userToken")]
        public string UserToken
        {
            get { return (string)base["userToken"]; }
            set { base["userToken"] = value; }
        }

        [ConfigurationProperty("userSecret")]
        public string UserSecret
        {
            get { return (string) base["userSecret"]; }
            set { base["userSecret"] = value; }
        }

        [ConfigurationProperty("sandbox", DefaultValue = true)]
        public bool Sandbox
        {
            get { return (bool) base["sandbox"]; }
            set { base["sandbox"] = true; }
        }

        [ConfigurationProperty("path", DefaultValue = "/")]
        public string Path
        {
            get { return (string) base["path"]; }
            set { base["path"] = value; }
        }

        [ConfigurationProperty("recursive", DefaultValue = true)]
        public bool Recursive
        {
            get { return (bool) base["recursive"]; }
            set { base["recursive"] = value; }
        }

        [ConfigurationProperty("local", DefaultValue = false)]
        public bool Local
        {
            get { return (bool) base["local"]; }
            set { base["local"] = value; }
        }
    }
}