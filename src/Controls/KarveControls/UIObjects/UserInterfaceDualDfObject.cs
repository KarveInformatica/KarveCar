using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.UIObjects
{
    public class UserInterfaceDualDfObject: UserInterfaceDfObject
    {
        public string TextContentFirst { set; get; }
        public string TextContentFirstWidth { set; get; }
        public bool IsReadOnlyFirst { set; get; }
        public bool IsReadOnlySecond { set; get; }
        public string DataFieldFirst { set; get; }
        public string DataFieldSecond { set; get; }
        public string TextContentSecond { get; set; }
    }
}
