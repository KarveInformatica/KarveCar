using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Prism.Mvvm;
using Telerik.WinControls.UI.Design;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// UiMultipleDfObject allows us to compose simple data fields in a horizontal or vertical way.
    /// </summary>
    public class UiMultipleDfObject: BindableBase, IUiObject
    {
       
        private ObservableCollection<IUiObject> _objectList = new ObservableCollection<IUiObject>();
        private string _currentListString = "";
        private string _tableName = "";
        private IList<string> _tables = new List<string>();
        private IList<string> _assistTables = new List<string>();
        private string _primaryKey;
        public enum DfKind
        {
            UiDataField,
            UiDualDfSearch
        };
        /// <summary>
        /// This method add a new data field
        /// </summary>
        /// <param name="item"></param>
        public void AddDataField(IUiObject item)
        {

            _objectList.Add(item);
            if (item is UiDualDfSearchTextObject)
            {
                UiDualDfSearchTextObject currentDfSearchTextObject = (UiDualDfSearchTextObject) item;
                _assistTables.Add(currentDfSearchTextObject.AssistTableName);
            }
            _tableName = item.TableName;
            _tables.Add(_tableName);
            _primaryKey = item.PrimaryKey;
            _currentListString = CreateStringList();
        }


        private string CreateStringList()
        {
            StringBuilder builder = new StringBuilder();

            foreach (IUiObject field in _objectList )
            {
                builder.Append(field.ToSQLString);
            }
            return builder.ToString();
        }
        public UiDfObject RemoveDataField(string fieldName)
        {
            UiDfObject dataDfObject=null;
            _currentListString = CreateStringList();
            return dataDfObject;
        }
        [XmlIgnore]
        public ObservableCollection<IUiObject> MultipleDataFields {
            get { return _objectList; }

            set
            {
                _objectList = value;
                RaisePropertyChanged("MultipleDataFields");
            }
        }
        public string Description { get; set; }
        [XmlIgnore]
        public CommonControl.DataType DataAllowed { get; set; }
        [XmlIgnore]
        public bool AllowedEmpty { get; set; }
        [XmlIgnore]
        public bool UpperCase { get; set; }
        [XmlIgnore]
        public string LabelText { get; set; }
        [XmlIgnore]
        public string LabelTextWidth { get; set; }
        [XmlIgnore]
        public bool LabelVisible { get; set; }
        [XmlIgnore]
        public bool IsReadOnly { get; set; }
       
        public string DataField { get; set; }

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
        [XmlIgnore]
        public DataTable ItemSource { get ; set; }

        public string ToSQLString
        {
            get { return _currentListString; }
            set { _currentListString = value; }
        }

        public string PrimaryKey {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
        /// <summary>
        /// Property that return a list of tablenames.
        /// </summary>
        public List<TableName> DataTableNames
        { 
            get
            {
                List<TableName> tables = new List<TableName>();
                foreach (string value in _tables)
                {
                    TableName t = new TableName();
                    t.Name = value;
                    tables.Add(t);
                }
                return tables;
            }
            set
            {
                foreach (TableName table in value)
                {
                    _tables.Add(table.Name);
                }
            }
         }
        public List<TableName> AssistTableNames
        {
            get
            {
                List<TableName> tables = new List<TableName>();
                foreach (string value in _assistTables)
                {
                    TableName t = new TableName();
                    t.Name = value;
                    tables.Add(t);
                }
                return tables;
            }
            set
            {
                foreach (TableName table in value)
                {
                    _assistTables.Add(table.Name);
                }
            }
        }
        [XmlIgnore]
        public IList<string> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }
        [XmlIgnore]
        public IList<string> AssistTables {

            get { return _assistTables; }
            set { _assistTables = value; }
        }
        public ObservableCollection<IUiObject> Values { get { return _objectList; } }

        public void SetSourceView(DataTable dataTable, string tableName)
        {
            int index = 0;
            IDictionary<int, UiDualDfSearchTextObject> newValues = new Dictionary<int, UiDualDfSearchTextObject>();
            foreach (var objectDataField in _objectList)
            {
                

                if (objectDataField is UiDualDfSearchTextObject)
                {
                    UiDualDfSearchTextObject currentDfSearchTextObject = (UiDualDfSearchTextObject)objectDataField;
                    if (currentDfSearchTextObject.AssistTableName == tableName)
                    {
                        currentDfSearchTextObject.SourceView = dataTable;
                        //currentDfSearchTextObject.Lookup = true;
                        newValues[index]=currentDfSearchTextObject;

                    }
                }
                if (objectDataField is UiGroupBoxMultipleObject)
                {
                  //  UiMultipleDfObject multipleDfObject = (UiMultipleDfObject) objectDataField;
                 //   multipleDfObject.SetSourceView(dataTable, tableName);
                }
                
                index++;

            }
            
            foreach (int key in newValues.Keys)
            {
                _objectList.RemoveAt(key);
                _objectList.Insert(key, newValues[key]);
            }
            

        }
        public void SetItemSource(DataTable dataTable, string tableName)
        {
            foreach (IUiObject value in _objectList)
            {
                if (value.TableName == tableName)
                {
                    value.ItemSource = dataTable;
                    
                }
                if (value is UiMultipleDfObject)
                {
                    UiMultipleDfObject multipleDfObject = (UiMultipleDfObject)value;
                    multipleDfObject.SetItemSource(dataTable, tableName);
                }
            }
        }

        public IList<IUiObject> FindObjects(DfKind kind)
        {
            IList<IUiObject> dataDfObjects = new List<IUiObject>();
            foreach (IUiObject value in _objectList)
            {
                
                if ((value is UiDualDfSearchTextObject) && (kind == DfKind.UiDualDfSearch))
                {
                    dataDfObjects.Add(value);         
                }
                else if ((value is UiDfObject) && (kind == DfKind.UiDataField))
                {
                    dataDfObjects.Add(value);
                }
                if (value is UiMultipleDfObject)
                {
                    UiMultipleDfObject multipleDfObject = (UiMultipleDfObject)value;
                    multipleDfObject.FindObjects(kind);
                }
            }
            return dataDfObjects;
        }
    }
}