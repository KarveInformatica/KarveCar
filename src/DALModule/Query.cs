using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Karve.DAL
{
    public class Query
    {
        public string QueryName { set; get; }
        public string QueryValue { set; get; }
        public int QueryType { set; get; }
        public string DbName { set; get; }
    }

    public class ModuleQueries
    {
        [XmlElement("Queries")]
        public List<Query> queryList = new List<Query>();
    }
}
