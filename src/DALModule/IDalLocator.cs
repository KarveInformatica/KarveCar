namespace DataAccessLayer
{
    public interface IDalLocator
    {
        IDalObject FindDalObject(string name);
    }
}
