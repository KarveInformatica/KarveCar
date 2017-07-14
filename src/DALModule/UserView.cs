using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Karve.DAL
{
    public class UserView : BasicDBView<User>
    {
        private const string _xmlFileQuery = "UserViewQueries.xml";
        public IList<Query> _queryValues = new List<Query>();
        public UserView()
        {
            LoadQueries();
            foreach (Query q in _queryValues)
            {
               _queryDictionary.Add(q.QueryName, q);
            }
        }
        public void LoadQueries()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ModuleQueries));
            TextReader reader = new StreamReader(@_xmlFileQuery);
            object obj = deserializer.Deserialize(reader);
            ModuleQueries XmlData = (ModuleQueries)obj;
            reader.Close();
        }
        public override string Name { get; set; }

        public override IList<User> FetchData()
        {

            throw new NotImplementedException();
        }

        public override IDBView<User> MergeViews(IDBView<User> first, IDBView<User> second)
        {
            throw new NotImplementedException();
        }

        public override void StoreData(IList<User> data)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteWork(string queryId)
        {
            throw new NotImplementedException();
        }
    }
}
