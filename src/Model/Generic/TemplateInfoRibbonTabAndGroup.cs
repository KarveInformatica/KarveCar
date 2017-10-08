using System.Windows.Controls.Ribbon;
using System.Collections.Generic;

namespace KarveCar.Model.Generic
{
    /// <summary>
    /// Plantilla con la info de los RibbonTab y de los RibbonGroup:<para/>
    /// ribbontab   -> RibbonTab del Ribbon, contendrá la List de RibbonGroups<para/>
    /// checkbox    -> Name del CheckBox en Configuración/Cinta Opciones<para/>
    /// ribbongroup -> List de RibbonGroups que contiene el RibbonTab<para/>
    /// </summary>
    public class TemplateInfoRibbonTabAndGroup
    {
        public RibbonTab ribbontab { get; set; }
        public string checkbox { get; set; }
        public List<RibbonGroup> ribbongroup { get; set; }
    }
}
