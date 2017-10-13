using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    public class UiDataFieldCheckBox : UiDfObject
    {
        public string Content { set; get; }
        public bool IsChecked { set; get; }
      
        public override string ToSQLString {
            get
            {
                string dataField= DataField;
                string outValue = "";
                if (!string.IsNullOrEmpty(dataField))
                {
                    outValue = dataField + ",";
                }
                return outValue;
            }
            }
    }
}
