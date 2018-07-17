using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    public interface IBudgetDataService: IDataProvider<IBudgetData, BudgetSummaryDto>, IIdentifier, IPageCounter
    {
    }
}