namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Option for charging 
    /// </summary>
    public class ChargeOptionDataObject: BaseAuxDataObject
    {
        private bool _isShowerChecked;
        private bool _isClientAccountChecked;
        private bool _isCashFlowChecked;
        private bool _isTeleChequeChecked;
        private bool _isPortfolioEffectsChecked;
        private bool _isSeatingFeeChecked;
        private bool _isNoRemittableChecked;

        public bool IsShowerChecked
        {
            set {_isShowerChecked = value; }
            get { return _isShowerChecked; }
        }

        public bool IsClientAccountChecked
        {
            set { _isClientAccountChecked = value; }
            get { return _isClientAccountChecked; }
        }

        public bool IsCashFlowChecked
        {
            set { _isCashFlowChecked = value; }
            get { return _isCashFlowChecked; }
        }

        public bool IsTeleChequeChecked
        {
            set { _isTeleChequeChecked = value; }
            get { return _isTeleChequeChecked; }
        }
        public bool IsPorfolioEffectsChecked
        {
            set { _isPortfolioEffectsChecked = value; }
            get { return _isPortfolioEffectsChecked; }
        }

        public bool IsSeatingFeeChecked
        {
            set { _isSeatingFeeChecked = value; }
            get { return _isSeatingFeeChecked; }
        }

        public bool IsNoRemittableChecked
        {
            set { _isNoRemittableChecked = value; }
            get { return _isNoRemittableChecked; }
        }
    }
}
