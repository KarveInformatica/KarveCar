using DataAccessLayer.DataObjects.Attributes;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Supplier sublicen data object
    /// </summary>
    [DBTable("SUBLICEN", "DbProvider=Sysbase")]
    public class SupplierSublicenDataObject
    {
        [DBField("Name=CODIGO",DBFieldType.String)]
        public string code { set; get; }

    }
}

