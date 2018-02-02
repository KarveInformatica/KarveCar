using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer
{
    internal class AssistDataService : IAssistDataService
    {
        private IHelperDataServices _helperDataServices;

        public AssistDataService(IHelperDataServices helperDataServices)
        {
            _helperDataServices = helperDataServices;
        }

        public Task<IValueObject> Serve(string assistName, string query)
        {
            throw new System.NotImplementedException();
        }
    }
}