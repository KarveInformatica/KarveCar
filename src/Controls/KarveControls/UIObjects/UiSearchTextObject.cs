using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.UIObjects
{
    public class UiSearchTextObject: UiDfObject
    {

        public UiSearchTextObject()
        {
            
        }
        public UiSearchTextObject(string label, string labelWidth) : base(label, labelWidth)
        {
            LabelText = label;
            LabelTextWidth = labelWidth;          
        }

        public string AssistTableName { set; get; }
        public string AssistDataField { set; get; }
        public string ButtonImage { set; get; }
        public bool Lookup { set; get; }
        public DataTable SourceView { set; get; }
        
    }
}
