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
    [Serializable]
    public class UiDfObject : BindableBase, IUiObject
    {


        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void ChangedField(IDictionary<string, object> eventDictionary);

        public event ChangedField OnChangedField;

        [XmlIgnore]
        public ICommand ChangedItem { set; get; }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

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

        public UiDfObject()
        {
            ChangedItem = new DelegateCommand<object>(ChangedObject);
        }

        private void ChangedObject(object value)
        {
            IDictionary<string, object> currentDictionary = value as IDictionary<string, object>;
            OnChangedField?.Invoke(currentDictionary);
        }

        public UiDfObject(string label, string labelTextWidth)
        {
            ChangedItem = new DelegateCommand<object>(ChangedObject);
            this.LabelText = label;
            this.LabelTextWidth = labelTextWidth;
        }

        [XmlAttribute("Description")]
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        [XmlAttribute("DataAllowed")]
        public CommonControl.DataType DataAllowed
        {
            set { _dataAllowed = value; }
            get { return _dataAllowed; }
        }

        [XmlAttribute("AllowedEmpty")]
        public bool AllowedEmpty
        {
            set { _allowedEmpty = value; }
            get { return _allowedEmpty; }
        }

        [XmlAttribute("UpperCase")]
        public bool UpperCase
        {
            set { _upperCase = value; }
            get { return _upperCase; }
        }

        [XmlAttribute("LabelText")]
        public string LabelText
        {
            set { _labelText = value; }
            get { return _labelText; }

        }

        [XmlAttribute("LabelVisible")]
        public bool LabelVisible
        {
            set { _labelVisible = value; }
            get { return _labelVisible; }
        }

        [XmlAttribute("Height")]
        public string Height
        {
            set { _height = value; }
            get { return _height; }
        }

        [XmlAttribute("TextContent")]
        public virtual string TextContent
        {
            set { _textContent = value; }
            get { return _textContent; }
        }

        [XmlAttribute("TextContentWidth")]
        public string TextContentWidth
        {
            set { _textContentWidth = value; }
            get { return _textContentWidth; }
        }

        [XmlAttribute("IsReadOnly")]
        public bool IsReadOnly
        {
            set { _isReadOnly = value; }
            get { return _isReadOnly; }
        }

        [XmlAttribute("DataField")]
        public string DataField
        {
            set { _dataField = value; }
            get { return _dataField; }
        }

        [XmlAttribute("TableName")]
        public string TableName
        {
            set { _tableName = value; }
            get { return _tableName; }
        }

        [XmlIgnore]
        public DataTable ItemSource
        {
            set { _itemSource = value; }
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
            set { _labelTextWidth = value; }
            get { return _labelTextWidth; }

        }

        [XmlAttribute("IsVisible")]

        public bool IsVisible
        {
            set { _isVisible = value; }
            get { return _isVisible; }
        }

        [XmlAttribute("PrimaryKey")]
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

            }
}