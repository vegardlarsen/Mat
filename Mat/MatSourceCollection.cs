using System;
using System.Configuration;
using Mat.Common;

namespace Mat
{
    [ConfigurationCollection(typeof(ISourceSettings), CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class MatSourceCollection : ConfigurationElementCollection
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
            var factories = SourceLocator.GetInstance().Factories;
            if (factories.ContainsKey(elementName))
            {
                return (ConfigurationElement)Activator.CreateInstance(factories[elementName].SettingsType);
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