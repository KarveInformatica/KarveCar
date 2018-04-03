using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  This service return a mapper. This violate the law of demeter.
    /// </summary>
    public interface IAssistDataService
    {
        IAssistMapper<BaseDto> Mapper { get; }
    }
}