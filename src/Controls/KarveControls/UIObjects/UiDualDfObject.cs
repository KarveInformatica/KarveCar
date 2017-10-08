using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KarveControls.UIObjects
{
    public class UiDualDfObject: UiDfObject
    {
        private string _dataFieldFirst;
        private string _dataFieldSecond;

        public string TextContentFirst { set; get; }
        public string TextContentFirstWidth { set; get; }
        public bool IsReadOnlyFirst { set; get; }
        public bool IsReadOnlySecond { set; get; }
        public string DataFieldFirst { set { _dataFieldFirst = value; }
                                       get { return _dataFieldFirst; }
                                     }
        public string DataFieldSecond { set { _dataFieldSecond = value; }
                                        get { return _dataFieldSecond; }
                                      }
        public string TextContentSecond { get; set; }
        [XmlIgnore]
        public override string ToSQLString
        {
            get
            {
                string name = DataFieldFirst + "," + DataFieldSecond + ",";
                return name;
            }
        }
    }
}
