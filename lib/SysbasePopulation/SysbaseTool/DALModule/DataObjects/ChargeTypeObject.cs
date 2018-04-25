namespace KarveDataAccessLayer.DataObjects
{
    public class ChargeTypeObject: BaseAuxDataObject
    {
       
        private object _numero;
        private object _cuenta;

        public object Numero
        {
            get { return _numero; }
            set
            {
                _numero =  value;
                OnPropertyChanged("Numero");
            }
        }
        public object Cuenta
        {
            get { return _cuenta; }
            set
            {
                _cuenta = value;
                OnPropertyChanged("Cuenta");
            }
        }
    }
}
