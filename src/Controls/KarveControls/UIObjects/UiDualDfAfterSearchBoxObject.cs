using System.Data;
namespace KarveControls.UIObjects
{
    public class UiDualDfAfterSearchBoxObject : IUiObject
    {
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
        public DataTable ItemSource { get; set; }
    }
}
