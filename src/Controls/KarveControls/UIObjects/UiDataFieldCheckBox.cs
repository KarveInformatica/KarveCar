using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// Data field check interface for the data template
    /// </summary>
    public class UiDataFieldCheckBox : UiDfObject
    {
        /// <summary>
        ///  Content for the data template
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        ///  Put this checked or unchecked following the template.
        /// </summary>
        public bool IsChecked { set; get; }
      /// <summary>
      /// This is the string needed for the query.
      /// </summary>
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
