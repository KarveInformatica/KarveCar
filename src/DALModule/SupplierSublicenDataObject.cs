namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Supplier sublicen data object
    /// </summary>
    [DBTable("SUBLICEN", "DbProvider=Sysbase")]
    public class SupplierSublicenDataObject
    {
        [DBField("Name=CODIGO",DataAccessLayer.DBFieldType.Integer)]
        public int code { set; get; }

    }
}

