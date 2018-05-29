using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace DataAccessLayer.MongoDB
{
    /*
    public class MongoHelper<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }
            
        public MongoHelper()
        {
           
            var con = new MongoConnectionStringBuilder(
                ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);

            var server = MongoServer.Create(con);
            var db = server.GetDatabase(con.DatabaseName);
            //Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }*/
}
