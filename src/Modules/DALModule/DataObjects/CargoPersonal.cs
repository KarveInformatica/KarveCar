using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveDataAccessLayer.DataObjects
{
    public class CargoPersonal : BaseAuxDataObject
    {
        #region Constructores
        public CargoPersonal() { this.ControlCambio = EControlCambio.Null; }
        public CargoPersonal(string codigo, string definicion, string ultimamodificacion, string usuario) : base(codigo, definicion, ultimamodificacion, usuario)
        {
         
        }
        #endregion       
       
    }
}
