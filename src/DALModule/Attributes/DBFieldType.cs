namespace DataAccessLayer.DataObjects.Attributes
{
   enum DBFieldType
    {
        Char,
        Integer,
        String,
        Boolean
    }
    enum NullPolicy
    {
        Allowed,
        NotAllowed
    }
    enum UniquePolicy
    {
        Yes,
        No
    }
    enum PrimaryKey
    {
        Yes,
        No
    }
}
