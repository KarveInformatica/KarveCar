namespace KarveDataServices.ViewObjects
{
    public class SupplierTypeViewObject : BaseViewObject
    {

        public short Codigo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string UltimaModifica { get; set; }
        bool IsInvalid()
        {
            if ((Nombre != null) && (Nombre.Length > 35))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            return false;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}