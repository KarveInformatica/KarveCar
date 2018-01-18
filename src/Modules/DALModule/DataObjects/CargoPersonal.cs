using static KarveCommon.Generic.Enumerations;

namespace KarveDataAccessLayer.DataObjects
{
    /// <summary>
    ///  dupllicated code.
    /// </summary>
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
