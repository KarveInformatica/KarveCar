namespace KarveDataServices.ViewObjects
{
    public class LanguageViewObject: BaseViewObject
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public bool IsInvalid()
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