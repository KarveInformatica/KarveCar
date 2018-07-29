using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Interface for getting value from budget data.
    /// </summary>
    public interface IBudgetData: IValidDomainObject, IValueObject<BudgetDto>
    {
    }
}
