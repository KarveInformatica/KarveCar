using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using Prism.Commands;
using Prism.Mvvm;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// UiDfObject is a user interface object that is able to be rendered as a data field.
    /// </summary>
    [Serializable]
    public class UiDfObject : BindableBase,IUiObject
    {

     /// <summary>
     ///  public delegate to detect a change in the datafiled
     /// </summary>
     /// <param name="eventDictionary"> Parameters returned from the datafield</param>
        public delegate void ChangedField(IDictionary<string, object> eventDictionary);

        public event ChangedField OnChangedField;

        [XmlIgnore]
        public ICommand ChangedItem { set; get; }

     
        private string _description;
        private CommonControl.DataType _dataAllowed;
        private bool _allowedEmpty;
        private bool _upperCase;
        private string _labelText;
        private bool _labelVisible;
        private string _textContent;
        private string _textContentWidth;
        private bool _isReadOnly;
        private bool _isVisible;
        private string _dataField;
        private string _tableName;
        private DataTable _itemSource;
        private string _labelTextWidth;
        private string _height;
        private string _primaryKey;
        private object _dataObject;
        /// <summary>
        /// UiDfObject. Object for a data field control binded with a data object or a data table
        /// </summary>
        public UiDfObject()
        {
            ChangedItem = new DelegateCommand<object>(ChangedObject);
        }

        private void ChangedObject(object value)
        {
            IDictionary<string, object> currentDictionary = value as IDictionary<string, object>;
            OnChangedField?.Invoke(currentDictionary);
        }
        /// <summary>
        /// UiDfObject. UiObject for data representation to be binded with a data object or a data table
        /// </summary>
        /// <param name="label">Visible lable of a UiDfObject</param>
        /// <param name="labelTextWidth"></param>
        public UiDfObject(string label, string labelTextWidth)
        {
            ChangedItem = new DelegateCommand<object>(ChangedObject);
            this.LabelText = label;
            this.LabelTextWidth = labelTextWidth;
        }
        /// <summary>
        /// Description of the field
        /// </summary>
        [XmlAttribute("Description")]
        public string Description
        {
            set { _description = value; RaisePropertyChanged(); }
            get { return _description; }
        }
        /// <summary>
        ///  Data allowed for having control validation rules.
        /// </summary>
        [XmlAttribute("DataAllowed")]
        public CommonControl.DataType DataAllowed
        {
            set { _dataAllowed = value; RaisePropertyChanged(); }
            get { return _dataAllowed; }
        }
        /// <summary>
        /// Property to be binded
        /// </summary>
        [XmlAttribute("AllowedEmpty")]
        public bool AllowedEmpty
        {
            set { _allowedEmpty = value; RaisePropertyChanged(); }
            get { return _allowedEmpty; }
        }

        [XmlAttribute("UpperCase")]
        public bool UpperCase
        {
            set { _upperCase = value; RaisePropertyChanged(); }
            get { return _upperCase; }
        }

        [XmlAttribute("LabelText")]
        public string LabelText
        {
            set { _labelText = value; RaisePropertyChanged(); }
            get { return _labelText; }

        }

        [XmlAttribute("LabelVisible")]
        public bool LabelVisible
        {
            set { _labelVisible = value; RaisePropertyChanged(); }
            get { return _labelVisible; }
        }

        [XmlAttribute("Height")]
        public string Height
        {
            set { _height = value; RaisePropertyChanged(); }
            get { return _height; }
        }

        [XmlAttribute("TextContent")]
        public virtual string TextContent
        {
            set { _textContent = value; RaisePropertyChanged(); }
            get { return _textContent; }
        }

        [XmlAttribute("TextContentWidth")]
        public string TextContentWidth
        {
            set { _textContentWidth = value; RaisePropertyChanged(); }
            get { return _textContentWidth; }
        }

        [XmlAttribute("IsReadOnly")]
        public bool IsReadOnly
        {
            set { _isReadOnly = value; RaisePropertyChanged(); }
            get { return _isReadOnly; }
        }

        [XmlAttribute("DataField")]
        public string DataField
        {
            set { _dataField = value; RaisePropertyChanged(); }
            get { return _dataField; }
        }

        [XmlAttribute("TableName")]
        public string TableName
        {
            set { _tableName = value; RaisePropertyChanged(); }
            get { return _tableName; }
        }

        [XmlIgnore]
        public DataTable ItemSource
        {
            set { _itemSource = value; RaisePropertyChanged(); }
            get { return _itemSource; }

        }
        public virtual string ToSQLString
        {
            get
            {
                string outValue = "";
                if (!string.IsNullOrEmpty(_dataField))
                {
                    outValue = _dataField + ",";
                }
                return outValue;
            }
        }

        [XmlAttribute("LabelTextWidth")]
        public string LabelTextWidth
        {
            set { _labelTextWidth = value; RaisePropertyChanged(); }
            get { return _labelTextWidth; }

        }

        [XmlAttribute("IsVisible")]

        public bool IsVisible
        {
            set { _isVisible = value; RaisePropertyChanged(); }
            get { return _isVisible; }
        }

        [XmlAttribute("PrimaryKey")]
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; RaisePropertyChanged(); }
        }
        [XmlElement("DataObject")]
        public object DataObject { get { return _dataObject; }
            set
            {
                _dataObject = value;
                RaisePropertyChanged();

            }
        }
    }
}