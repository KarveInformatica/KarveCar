using System;
using System.Data;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    public class UiDualDfAfterSearchBoxObject : IUiObject
    {
        private string _sqlString;
        private string _primaryKey;
        public string Description { get ; set; }
        public CommonControl.DataType DataAllowed { get; set; }
        public bool AllowedEmpty { get; set; }
        public bool UpperCase { get ; set ; }
        public string LabelText { get ; set; }
        public string LabelTextWidth { get ; set; }
        public bool LabelVisible { get ; set; }
        public bool IsReadOnly { get; set ; }
        public string DataField { get ; set; }
        public string TableName { get ; set; }
        [XmlIgnore]
        public DataTable ItemSource { get; set; }
        [XmlIgnore]
        public string ToSQLString
        {
            get
            {
                _sqlString += ",";
                return _sqlString;
            }
        }

        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
    }
}
