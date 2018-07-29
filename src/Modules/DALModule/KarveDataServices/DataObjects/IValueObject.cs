namespace KarveDataServices
{
    public interface IValueObject<T>
    {
       T Value { set; get; }
    }
}