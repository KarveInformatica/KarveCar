using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace DataAccessLayer.DataObjects
{
    public class BancoDataObject : BaseAuxDataObject
    {
        #region Constructores
        public BancoDataObject() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public BancoDataObject(string codigo, string definicion, string swift, string ultimamodificacion, string usuario): base(codigo, definicion, ultimamodificacion, usuario)
        {
            this.swift  = swift;

        }
        #endregion
        

        private string swift;
        public string Swift
        {
            get { return swift; }
            set
            {
                swift = value;
                OnPropertyChanged("Swift");
            }
        }
    }
}
