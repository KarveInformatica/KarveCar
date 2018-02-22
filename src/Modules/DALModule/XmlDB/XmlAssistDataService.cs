using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.XmlDB
{
    internal class XmlAssistDataService : IAssistDataService
    {
        public Task<IValueObject> Serve(string assistName, string query)
        {
            throw new System.NotImplementedException();
        }
    }
}