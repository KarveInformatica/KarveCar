using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using KarveCommon.Generic;

namespace KarveControls.UIObjects
{
    /// <summary>
    ///  Common interface for a collection of user object. An user object is a control abstraction to be 
    /// binded to a data object or data table. The responsability of an user object to allow a data template of 
    /// our custom control within a collection view.
    /// </summary>
    public interface IUiObject
    {
        /// <summary>
        ///  Description of the user object
        /// </summary>
        string Description { set; get; }
        /// <summary>
        /// Data Type of the user object
        /// </summary>
        DataType DataAllowed { set; get; }
        /// <summary>
        /// Is empty is allowed.
        /// </summary>
        bool AllowedEmpty { set; get; }
        /// <summary>
        /// UpperCase of the object
        /// </summary>
        bool UpperCase { set; get; }
        /// <summary>
        /// LabelText
        /// </summary>
        string LabelText { set; get; }
        /// <summary>
        ///  LabelTextWidth
        /// </summary>
        string LabelTextWidth { set; get; }
        /// <summary>
        ///  Lable Visible
        /// </summary>
        bool LabelVisible { set; get; }
        /// <summary>
        /// IsReadOnly 
        /// </summary>
        bool IsReadOnly { set; get; }
        /// <summary>
        /// DataField.
        /// </summary>
        string DataField { set; get; }

        /// <summary>
        ///  TableName
        /// </summary>
        string TableName { set; get; }
        // Item source

        /// <summary>
        /// Source of a ui object
        /// </summary>
        object ItemSource { set; get; }
        /// <summary>
        ///  To SQL String
        /// </summary>
        string ToSQLString { get; }
        /// <summary>
        ///  PrimaryKey.
        /// </summary>
        string PrimaryKey { get; set; }
     
    }
}