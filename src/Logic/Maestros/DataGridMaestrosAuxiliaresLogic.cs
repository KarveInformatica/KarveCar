using KarveCar.Model.Generic;
using KarveCar.Properties;
using KarveCar.Utility;
using KarveCommon.Generic;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;

namespace KarveCar.Logic.Maestros
{
    public class DataGridMaestrosAuxiliaresLogic
    {

        /// <summary>
        ///  Elimina un registro del DataGrid
        ///  TODO:  This has an embeeded meessage in spanish, the method is static. exception shall be handled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridDelete(object sender, KeyEventArgs e)
        {
            try
            {
                Enumerations.EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;
                TabItem tabitem = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.TabItem;
                DataGrid datagrid = tabitem.Content as DataGrid;
                /** FIXME: the idea here shall be different. I shall pass just the candidate to the delete to the view model. DataGridViewModel
                 * and than when i sent savecommand i can send to CareKeeperService the elements to restore and than after that 
                 * I can do/undo the stuff..
                 */
                if (e.Key == Key.Delete )
                {   //Se consulta si realmente se desea eliminar el registro
                    if (!(MessageBox.Show(Resources.msgEliminarRegistro, Resources.msgEliminarRegistroTitulo, MessageBoxButton.YesNo) == MessageBoxResult.No))
                    {
                        foreach (var itemdatagrid in datagrid.SelectedItems)
                        {
                            foreach (var itemobscollection in auxobscollection.GenericObsCollection)
                            {   //Se comprueba que el SelectedItem corresponda con el object del GenericObservableCollection
                                if (itemdatagrid == itemobscollection)
                                {   //Se marca como delete la propiedad ControlCambio del object del GenericObservableCollection
                                    IDataGridRowChange idatagridrowchange = itemobscollection as IDataGridRowChange;
                                    idatagridrowchange.ControlCambio = Enumerations.EControlCambio.Delete;
                                    
                                    idatagridrowchange.UltimaModificacion = ManageGenericObject.GetUltModi();
                                    idatagridrowchange.Usuario = ManageGenericObject.GetUsuario();

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Se marca como insert/update la propiedad ControlCambio del SelectedItem del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridInsertEdit(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {   //Se recupera la EOpcion, el GenericObservableCollection, el TabItem y el DataGrid del TabItem activo
                Enumerations.EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;
                TabItem tabitem = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.TabItem;
                DataGrid datagrid = tabitem.Content as DataGrid;

                /* here i dont mark the row. just sending command or insert to the view model and than i can unedit or some things similar in the row.
                 */
                foreach (var itemdatagrid in datagrid.SelectedItems)
                {
                    foreach (var itemobscollection in auxobscollection.GenericObsCollection)
                    {   //Se comprueba que el SelectedItem corresponda con el object del GenericObservableCollection
                        if (itemdatagrid == itemobscollection)
                        {   //Se marca como insert/update según corresponda la propiedad ControlCambio
                            //del object del GenericObservableCollection
                            IDataGridRowChange idatagridrowchange = itemobscollection as IDataGridRowChange;
                            idatagridrowchange.ControlCambio = e.Row.IsNewItem ? Enumerations.EControlCambio.Insert : Enumerations.EControlCambio.Update;

                            idatagridrowchange.UltimaModificacion = ManageGenericObject.GetUltModi();
                            idatagridrowchange.Usuario = ManageGenericObject.GetUsuario();

                            break;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }    
}
