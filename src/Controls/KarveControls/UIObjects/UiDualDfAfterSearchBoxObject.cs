using System;
using System.Data;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// User object of a search box.
    /// </summary>
    public class UiDualDfAfterSearchBoxObject : IUiObject
    {
        private string _sqlString;
        private string _primaryKey;
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get ; set; }
        /// <summary>
        ///  Data Allowrd
        /// </summary>
        public ControlExt.DataType DataAllowed { get; set; }
        /// <summary>
        ///  Allowed empty
        /// </summary>
        public bool AllowedEmpty { get; set; }
        /// <summary>
        ///  Uppercase
        /// </summary>
        public bool UpperCase { get ; set ; }
        /// <summary>
        ///  LabelText
        /// </summary>
        public string LabelText { get ; set; }
        /// <summary>
        ///  LabelText width
        /// </summary>
        public string LabelTextWidth { get ; set; }
        /// <summary>
        ///  Label Visible
        /// </summary>
        public bool LabelVisible { get ; set; }
        /// <summary>
        ///  Is readonly
        /// </summary>
        public bool IsReadOnly { get; set ; }
        /// <summary>
        ///  Data Field
        /// </summary>
        public string DataField { get ; set; }
        /// <summary>
        ///  Name of the table
        /// </summary>
        public string TableName { get ; set; }
        /// <summary>
        ///  Source of the item
        /// </summary>
        [XmlIgnore]
        public object ItemSource { get; set; }
        /// <summary>
        ///  add a part of the query
        /// </summary>
        [XmlIgnore]
        public string ToSQLString
        {
            get
            {
                _sqlString += ",";
                return _sqlString;
            }
        }
        /// <summary>
        ///  PrimaryKey.
        /// </summary>
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
    }
}
