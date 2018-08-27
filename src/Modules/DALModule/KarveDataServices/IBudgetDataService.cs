using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveDataServices
{
    public interface IBudgetDataService: IDataProvider<IBudgetData, BudgetSummaryViewObject>, IIdentifier, IPageCounter
    {
    }
}