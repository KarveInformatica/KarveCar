using static KarveCommon.Generic.Enumerations;

namespace KarveCar.Model.Generic
{
    public interface IDataGridRowChange
    {
        string UltimaModificacion { get; set; }
        string Usuario { get; set; }
        EControlCambio ControlCambio { get; set; }
    }
}
