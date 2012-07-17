using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Mat.Common;

namespace Mat.Sources.Static
{
    [ConfigurationCollection(typeof(StaticImageSourceLocation), CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class StaticImageSourceSettings : ConfigurationElementCollection, ISourceSettings
    {
        public StaticImageSourceSettings()
        {
            Id = Guid.NewGuid();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            // not used but method has to be overridden
            return null;
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new StaticImageSourceLocation();
        }

        protected override bool IsElementName(string elementName)
        {
            return true;
        }

        protected override string ElementName
        {
            get { return String.Empty; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return element;
        }

        [ConfigurationProperty("id")]
        public Guid Id
        {
            get { return (Guid)base["id"]; }
            set { base["id"] = value; }
        }
    }
}
