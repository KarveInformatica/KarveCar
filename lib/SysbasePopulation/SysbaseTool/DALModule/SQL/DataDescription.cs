using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ExtendedXmlSerialization;

namespace DataAccessLayer.SQL
{
    /// <summary>
    /// Collection of data to be present in the query.
    /// When the user wants to 
    /// </summary>
    [Serializable]
    public class DataCollection
    {
        List<Table> _dataDescriptions = new List<Table>();
        /// <summary>
        /// Data Description.
        /// </summary>
        [XmlElement("Tables")]
        public List<Table> DataList
        {
            set { _dataDescriptions = value; }
            get { return _dataDescriptions; }
        }
        /// <summary>
        /// This adds a table to the collection;
        /// </summary>
        /// <param name="t">Table to add to the collection</param>
        public void AddTable(Table t)
        {
            var currentTable = from table in DataList
                where table.Name == t.Name
                select table;
            if (!currentTable.Any())
            {
                _dataDescriptions.Add(t);
            }
        }
        /// <summary>
        ///  Table to remove from the collection.
        /// </summary>
        /// <param name="t">Table to be removed from the collection</param>
        public void RemoveTable(Table t)
        {
            var currentTable = from table in DataList
                where table.Name == t.Name
                select table;
            if (currentTable.Any())
            {
                Table tmpTable = currentTable.ToList()[0];
                _dataDescriptions.Remove(tmpTable);
            }
        }
        

    }
    [Serializable]
    public class Table
    {
        private List<Field> _dataFields = new List<Field>();
        private string _name = "";
        /// <summary>
        ///  This is a table description in xml.
        /// </summary>
        public Table()
        { }

        /// <summary>
        ///  Name to be saved.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        /// <summary>
        /// Data fields to be saved.
        /// </summary>
        [XmlElement("DataFields")]
        public List<Field> DataFields
        {
            set { _dataFields = value; }
            get { return _dataFields; }
        }
        /// <summary>
        ///  This adds a new field.
        /// </summary>
        /// <param name="field"></param>
        public void AddField(Field field)
        {
            _dataFields.Add(field);
        }
        /// <summary>
        /// This remove a field.
        /// </summary>
        /// <param name="f">Field to be removed.</param>
        public void RemoveField(Field f)
        {
            var fieldName = from field in _dataFields
                where field.Name == f.Name
                select field;
            if (fieldName.Any())
            {
                _dataFields.Remove(fieldName.ToList()[0]);
            }
        }
        /// <summary>
        ///  Look if two table have the same fields.
        /// </summary>
        /// <param name="tableObject">Table</param>
        /// <returns></returns>
        public override bool Equals(object tableObject)
        {
            Table t = (Table)tableObject;
            if (t != null)
            {
                var firstList = t.DataFields.OrderByDescending(x => x.Name);
                var secondList = _dataFields.OrderByDescending(x => x.Name);
                bool equal = firstList.SequenceEqual(secondList);
                return equal;
            }

            return false;
        }

        protected bool Equals(Table other)
        {
            return Equals(_dataFields, other._dataFields) && string.Equals(_name, other._name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_dataFields != null ? _dataFields.GetHashCode() : 0) * 397) ^ (_name != null ? _name.GetHashCode() : 0);
            }
        }
    }
    /// <summary>
    ///  A table has different fields.
    /// </summary>
    [Serializable]
    public class Field
    {
        private string _name ="";
        /// <summary>
        ///  Field constructor.
        /// </summary>
        public Field()
        {
            
        }
        /// <summary>
        ///  Field constructor
        /// </summary>
        /// <param name="name">Name to be constructed</param>
        public Field(string name)
        {
            _name = name;
        }
        [XmlAttribute("Name")]
        public string Name {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

    }
    /// <summary>
    /// Data Loader.
    /// </summary>
    public class DataLoader
    {
        /// <summary>
        /// This loads the xml data list for creating the query. 
        /// </summary>
        /// <param name="pathName">Path.</param>
        public DataCollection LoadXmlData(string pathName)
        {
            Uri uri = new Uri(pathName);
            TextReader reader = new StreamReader(uri.LocalPath);
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            string xmlValue = reader.ReadToEnd();
            DataCollection coll = null;
            var collection = serializer.Deserialize<DataCollection>(xmlValue);
            coll = (DataCollection) collection;
            return coll;
        }
        /// <summary>
        /// Save data fields to a file.
        /// </summary>
        /// <param name="collection">Data collection</param>
        /// <param name="pathName">Path name</param>
        public void SaveXmlData(DataCollection collection, string pathName)
        {
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            var xml = serializer.Serialize(collection);
            TextWriter writer= new StreamWriter(pathName);
            writer.Write(xml);
            writer.Close();
        }

    }
}
