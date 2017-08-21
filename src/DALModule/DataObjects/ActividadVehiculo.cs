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
