using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class MongoAssistDataAccessLayer : IAssistDataService
    {
        public IAssistMapper<BaseDto> Mapper { get; }
    }
}