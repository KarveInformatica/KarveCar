using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveControls.UIObjects
{
    public class DualDfSearchBox: UserInterfaceDfObject
    {
        public string AssistTableName { set; get; }
        public string TextContentFirst { set; get; }
        public string TextContentSecond { set; get; }
        public string TextContentFirstWidth { set; get; }
        public string TextContentSecondWidth { set; get; }
        public string ButtonImage { set; get; }
        public bool Lookup { set; get; }
        public DataTable SourceView { set; get; }
        public string DataFieldFirst { set; get; }
        public string DataFieldSecond { set; get; }
        public IList<string> DataFields { set; get; }
    }

    
}
