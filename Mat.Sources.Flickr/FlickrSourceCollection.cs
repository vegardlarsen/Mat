using System;
using System.Collections.Generic;
using System.Configuration;

namespace Mat.Sources.Flickr
{
    [ConfigurationCollection(typeof(IFlickrApiSource), CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FlickrSourceCollection : ConfigurationElementCollection
    {
        #region Collection items
        protected override bool IsElementName(string elementName)
        {
            return true;
        }

        protected override string ElementName
        {
            get { return string.Empty; }
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            var factories = new Dictionary<string, Type>
                {
                    { "photostream", typeof(PhotostreamSettings) }
                };
            if (factories.ContainsKey(elementName))
            {
                return (ConfigurationElement)Activator.CreateInstance(factories[elementName]);
            }
            throw new ArgumentException("No factory found for " + elementName);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            // not used but method has to be overridden
            return null;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return element;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}