using System;
using System.Data;

namespace KarveControls.UIObjects
{
    public interface IUiObject
    { 
        string Description { set; get; }
        CommonControl.DataType DataAllowed { set; get; }
        bool AllowedEmpty { set; get; }
        bool UpperCase { set; get; }
        string LabelText { set; get; }
        string LabelTextWidth { set; get; }
        bool LabelVisible { set; get; }
        bool IsReadOnly { set; get; }
        string DataField { set; get; }
        string TableName { set; get; }
        DataTable ItemSource { set; get; }        
    }
}