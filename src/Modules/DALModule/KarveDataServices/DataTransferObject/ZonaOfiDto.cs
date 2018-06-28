namespace KarveDataServices.DataTransferObject
{
    public class ZonaOfiDto: BaseDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Plaza { get; set; }

        bool IsInvalid()
        {
            var errors = base.HasErrors;
            if (!errors)
            {
                if ((Nombre != null) && (Nombre.Length > 35))
                {
                    return true;
                }
                if ((Plaza != null) && (Plaza.Length > 2))
                {
                    return true;
                }
            }
            return errors;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}