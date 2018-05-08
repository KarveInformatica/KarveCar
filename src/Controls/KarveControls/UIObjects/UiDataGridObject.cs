using System.Data;
using KarveCommon.Generic;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// The UiDataGridObject. User object for the data grid.
    /// </summary>
    public class UiDataGridObject : IUiObject
    {
        private string _primaryKey;
        /// <summary>
        ///  Description 
        /// </summary>
        public string Description { get ; set ; }

        /// <summary>
        ///  Data Allowed
        /// </summary>
        public DataType DataAllowed { get ; set ; }
        /// <summary>
        ///  If it is allowed empty.
        /// </summary>
        public bool AllowedEmpty { get ; set ; }
        /// <summary>
        ///  UpperCase.
        /// </summary>
        public bool UpperCase { get ; set; }
        /// <summary>
        ///  LabelText
        /// </summary>
        public string LabelText { get ; set ; }
        /// <summary>
        ///  LabelTextWidth. The width of a label text.
        /// </summary>
        public string LabelTextWidth { get ; set ; }
        /// <summary>
        ///  Label Visible or not.
        /// </summary>
        public bool LabelVisible { get ; set ; }
        /// <summary>
        ///  IsReadOnly or not.
        /// </summary>
        public bool IsReadOnly { get ; set ; }
        /// <summary>
        ///  If it is visible or not
        /// </summary>
        public bool IsVisible { get ; set ; }
        /// <summary>
        ///  Data field name
        /// </summary>
        public string DataField { get ; set; }
        /// <summary>
        ///  TableName
        /// </summary>
        public string TableName { get ; set ; }
        /// <summary>
        ///  ItemSource.
        /// </summary>
        public object ItemSource { get ; set; }
        /// <summary>
        ///  String of the query.
        /// </summary>
        public string ToSQLString
        {
            get { return string.Empty; }
        }
        /// <summary>
        ///  Primary Key of the query.
        /// </summary>
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
    }
}
