using KarveCar.Model.Sybase;
using KarveCar.Utility;
using KarveCar.View;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.Logic.Configuracion
{
    public class RibbonOptionLogic
    {
        /// <summary>
        /// Guarda la configuración por defecto (Variablesglobales.Dictionary<ERibbonTab, RibbonTabAndGroup> ribbontabdictionary )
        /// de los RibbonGroups de los RibbonTab seleccionados
        /// </summary>
        /// <param name="opcion"></param>
        public static void SaveRibbonOptions(EOpcion opcion)
        {
            try
            {
                TabItem tabitem = tabitemdictionary.Where(c => c.Key == opcion).FirstOrDefault().Value.TabItem;
                CintaOpcionesUserControl cintaopcionesusercontrol = tabitem.Content as CintaOpcionesUserControl;

                UserAndDefaultConfig.SetDefaultRibbonTabConfig(cintaopcionesusercontrol);
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

        /// <summary>
        /// Desmarca todos los CheckBox
        /// </summary>
        /// <param name="opcion"></param>
        public static void DeleteRibbonOptions(EOpcion opcion)
        {
            try
            {
                TabItem tabitem = tabitemdictionary.Where(c => c.Key == opcion).FirstOrDefault().Value.TabItem;
                CintaOpcionesUserControl cintaopcionesusercontrol = tabitem.Content as CintaOpcionesUserControl;

                foreach (Control control in cintaopcionesusercontrol.grdCintaOpciones.Children)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkbox = control as CheckBox;
                        checkbox.IsChecked = false;
                    }
                }
            }
            catch (Exception ex)
            {            
                ErrorsGeneric.MessageError(ex);
            }
        }
    }
}
