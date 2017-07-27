using KarveCar.Logic.Generic;
using KarveCar.Model.Generic;
using KarveCar.Model.Sybase;
using KarveCar.Utility;
using KarveCar.View;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Logic.Configuracion
{
    public class RibbonOptionLogic
    {
        /// <summary>
        /// Añade un UserControl al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// Se añade el EOpcion y el nuevo TabItem al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos.
        /// </summary>
        /// <param name="opcion"></param>
        public static void PrepareTabItemUserControl(EOpcion opcion)
        {
            try
            {
                if (tabitemdictionary.Where(p => p.Key == opcion).Count() == 0)
                {
                    CintaOpcionesUserControl cintaopcionesusercontrol = new CintaOpcionesUserControl();
                    //Se crea el Tabitem
                    TabItem tabitem = TabItemLogic.CreateTabItemDataGrid(opcion);

                    //Se añade un nuevo object CintaOpcionesUserControl al TabItem
                    tabitem.Content = cintaopcionesusercontrol;

                    //Se añade el EOpcion y el nuevo TabItem al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos
                    tabitemdictionary.Add(opcion, new TemplateInfoTabItem(tabitem));

                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TabItem.Focus();
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

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
