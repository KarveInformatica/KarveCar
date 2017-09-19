using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.UIObjects
{
    public class UserInterfaceSearchTextObject: UserInterfaceDfObject
    {
        public string AssistTableName { set; get; }
        public string AssistDataField { set; get; }
        public string ButtonImage { set; get; }
        public bool Lookup { set; get; }
        public DataTable SourceView { set; get; }
    }
}
