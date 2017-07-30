using KarveCar.Model.Generic;
using KarveCommon.Generic;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace DataAccessLayer.DataObjects
{
    public class ActividadVehiculo : BaseAuxDataObject
    {
        #region Constructores
        public ActividadVehiculo():base()
        {
        }
        public ActividadVehiculo(string codigo, string definicion, string ultimamodificacion, string usuario): base(codigo, definicion, ultimamodificacion, usuario)
        {
        }
        #endregion
    }
}
