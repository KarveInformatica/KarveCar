using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.MongoDB
{
    internal class AssistMongoDBServices : IAssistDataService
    {
        private INoSqlExecutor _executor;

        public AssistMongoDBServices(INoSqlExecutor executor)
        {
            _executor = executor;
        }

        public Task<IValueObject> Serve(string assistName, string query)
        {
            throw new System.NotImplementedException();
        }
    }
}