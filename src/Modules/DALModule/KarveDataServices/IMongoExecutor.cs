using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /*
     *
     * var con = new MongoConnectionStringBuilder(
            ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
 
        var server = MongoServer.Create(con);
        var db = server.GetDatabase(con.DatabaseName);
        Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
     */
    interface IMongoExecutor : IConnectionOpener
    {

    }
    
}
