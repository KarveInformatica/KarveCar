using System;
using System.Data;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    public class UiDataArea : IUiObject
    {
        private string _description;
        private string _primaryKey;
        private CommonControl.DataType _dataType;
        private bool _allowedEmpty;
        private bool _upperCase;
        private string _labelText;
        private string _labelTextWidth;
        private bool _labelVisible;
        private bool _isReadOnly;
        private string _DataField;
        private string _TableName;
        [XmlIgnore]
        private DataTable _itemSource;
        public string Description { get => _description; set => _description = value; }
        public CommonControl.DataType DataAllowed { get => _dataType; set => _dataType = value; }
        public bool AllowedEmpty { get => _allowedEmpty; set => _allowedEmpty=value; }
        public bool UpperCase { get => _upperCase; set => _upperCase=value; }
        public string LabelText { get => _labelText; set => _labelText=value; }
        public string LabelTextWidth { get => _labelTextWidth; set => _labelTextWidth=value; }
        public bool LabelVisible { get => _labelVisible; set => _labelVisible=value; }
        public bool IsReadOnly { get => _isReadOnly; set => _isReadOnly=value; }
        public string DataField { get => _DataField; set => _DataField=value; }
        public string TableName { get => _TableName; set => _TableName=value; }
        [XmlIgnore]
        public DataTable ItemSource { get => _itemSource; set => _itemSource=value; }
        
        public string ToSQLString
        {
            get { return _DataField + ","; }
        }

        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
    }
}
