using KarveCar.Logic.Generic;
using KarveCar.Model.Generic;
using KarveCar.Model.SQL;
using KarveCar.Utility;
using KarveCar.View;
using KarveCommon.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCar.Logic.Maestros
{
    public class MaestrosAuxiliaresLogic
    {
        /// <summary>
        /// Añade un nuevo TabItem al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        public static void PrepareTabItemDataGrid(EOpcion opcion)
        {
            if (tabitemdictionary.Where(p => p.Key == opcion).Count() == 0)
            {
                //Se recuperan los datos de la correspondiente tabla de la BBDD según la EOpcion recibida por params                
                // TODO: remove all this make in a way that it is using all the aux.
                string nombretabladb = ribbonbuttondictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.nombretabladb;
                string sql = string.Format(ScriptsSQL.SELECT_ALL_BASICA, nombretabladb);
                GenericObservableCollection genericobscollection = GetValuesFromDBGeneric.GetValuesFromDB(opcion, sql);
                    //Se crea un nuevo DataGrid dentro de un nuevo TabItem con los datos del GenericObservableCollection

                /*  else
                  {
                      DalLocator loc = DalLocator.GetInstance();
                      IDalObject dalObject =  loc.FindDalObject(option.ToString());
                      genericobscollection = dalObject.GetItems();
                  }
                  */
                //Se crea un nuevo DataGrid dentro de un nuevo TabItem con los datos del GenericObservableCollection
                CreateTabItemDataGrid(option, genericobscollection);                
                CreateTabItemDataGrid(option, genericobscollection);                
                CreateTabItemDataGrid(opcion, genericobscollection);                
            }
            else
            {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                tabitemdictionary.Where(z => z.Key == option).FirstOrDefault().Value.TabItem.Focus();
                tabitemdictionary.Where(z => z.Key == option).FirstOrDefault().Value.TabItem.Focus();
                tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TabItem.Focus();
            }
        }

        /// <summary>
        /// Añade a un nuevo DataGridUserControl los datos del GenericObservableCollection (genericobscollection) recibido por params. 
        /// El nombre de las propiedades del object del GenericObservableCollection (genericobscollection) corresponderán con los 
        /// respectivos Headers. Se añade el DataGridUserControl en un nuevo TabItem (tbitem).
        /// Se añade el EOpcion, el GenericObservableCollection recibido por params (como origin y copy) y el nuevo TabItem,  
        /// al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="genericobscollection"></param>
        private static void CreateTabItemDataGrid(EOpcion opcion, GenericObservableCollection genericobscollection)
        {
            if (genericobscollection.GenericObsCollection.Count != 0)
            {   
                /* this can easily replaced creating a tabcontrol custom */

                //Creamos el DataGrid
                DataGridUserControl datagrid = new DataGridUserControl();

                #region Se añade la ObservableCollection<object> directamente como el datagrid.ItemsSource, rellena las columnas según las propiedades que tenga el object, tenga o no tenga datos; el header será el nombre de cada propiedad del object

                //SetTrigger(datagrid);
                #endregion

                #region Se crean los DataGridTextColumn dinámicamente, dándole el nombre al header, y binding cada columna según establecido en la List<DBCriterios> del object; se añade cada columna individualmente al DataGrid
                ////Creamos los DataGridTextColumn
                //DataGridTextColumn column;
                //List<TemplateInfoDB> templateinfodb = ribbonbuttondictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.templateinfodb;
                //foreach (var item in templateinfodb)
                //{
                //    //var binding = new Binding();
                //    //binding.Path = new PropertyPath(item.datagridheader);
                //    //binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");

                //    column = new DataGridTextColumn();
                //    column.Header = item.datagridheader; //binding.Path;
                //    column.Binding = new Binding(item.nombrepropiedadobj);
                //    datagrid.Columns.Add(column);
                //}

                ////Añadimos los valores al Datagrid
                //foreach (var item in genericobscollection.GenericObsCollection)
                //{
                //    datagrid.Items.Add(item);
                //}
                #endregion

                //datagrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("SelectedItem") { Source = genericobscollection });
                //Se añade al DataGridUserControl el GenericObservableCollection recibido por params como ItemsSource
                //datagrid.ItemsSource = genericobscollection.GenericObsCollection;
                datagrid.ItemsSource = genericobscollection.GenericObsCollection;

                //Se crea el Tabitem
                TabItem tabitem = TabItemLogic.CreateTabItemDataGrid(opcion);
                TabItem tabitem = TabItemLogic.CreateTabItemDataGrid(opcion);
                TabItem tabitem = TabItemLogic.CreateTabItem(opcion);

                //Se añade el EOpcion, el GenericObservableCollection recibido por params (como origin y copy) y el nuevo TabItem,  
                //al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos
                tabitemdictionary.Add(opcion, new TemplateInfoTabItem(genericobscollection, tabitem));

                //Se añade el DataGridUserControl al TabItem
                tabitem.Content = datagrid;                
            }
        }
    }
}
