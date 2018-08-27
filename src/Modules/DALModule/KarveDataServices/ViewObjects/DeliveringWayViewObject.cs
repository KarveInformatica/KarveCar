namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  DeliveringWayViewObject.
    /// </summary>
    public class DeliveringWayViewObject: BaseViewObject
    {
        public string Codigo { set; get; }
        public string Nombre { set; get; }
        public bool IsInvalid()
        {
            if ((Nombre != null) && (Nombre.Length > 100))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}
