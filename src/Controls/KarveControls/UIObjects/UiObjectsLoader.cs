using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ExtendedXmlSerialization;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// This class serialize and deserialize a collection of UiObjects.
    /// </summary>
    public class UiObjectsLoader
    {
        /// <summary>
        /// This method loads a collection of UI objects from a file
        /// An UIObject is an object that it is useful for rendering and it has been already 
        /// binded to a database field.
        /// </summary>
        /// <param name="path">Path of the file to be loaded</param>
        /// <returns></returns>
        public ObservableCollection<IUiObject> LoadCollection(string path)
        {
            TextReader reader = new StreamReader(path);
            string xml = reader.ReadToEnd();

            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            var collection = serializer.Deserialize<ObservableCollection<IUiObject>>(xml);
            return collection;
        }
        /// <summary>
        /// This method save a collection of UiObjects to disk
        /// </summary>
        /// <param name="observableCollection">Observable collection of objects</param>
        /// <param name="path">Path of the file to be saved</param>
        public void SaveCollection(ObservableCollection<IUiObject> observableCollection, string path)
        {
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            var xml = serializer.Serialize(observableCollection);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            using (XmlTextWriter writer = new XmlTextWriter(path, null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }
        
    }
}
