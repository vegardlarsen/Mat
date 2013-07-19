using System;
using System.Configuration;
using Mat.Common;

namespace Mat.Sources.Static
{
    [ConfigurationCollection(typeof(StaticMediaSourceLocation), CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class StaticMediaSourceSettings : ConfigurationElementCollection, ISourceSettings
    {
        public StaticMediaSourceSettings()
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
            return new StaticMediaSourceLocation();
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
