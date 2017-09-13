using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Generic
{
    public interface IDataGridRowChange
    {
        string UltimaModificacion { get; set; }
        string Usuario { get; set; }
        EControlCambio ControlCambio { get; set; }
    }
}
