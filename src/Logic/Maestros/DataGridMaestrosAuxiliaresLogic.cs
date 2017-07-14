using KarveCar.Model.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static KarveCar.Model.Generic.RecopilatorioCollections;

namespace KarveCar.Logic.Maestros
{
    public class DataGridMaestrosAuxiliaresLogic
    {
        public static void DataGridDelete(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var datagrid = (DataGrid) sender;
                if (datagrid.CanUserDeleteRows == true)
                {
                    //if (MessageBox.Show("Are you sure you want to delete this employee?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                    //{
                    //MessageBox.Show("grid.SelectedItems.Count: " + grid.SelectedItems.Count.ToString());
                    foreach (var row in datagrid.SelectedItems)
                    {
                        //MessageBox.Show("DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)" + "\n\n" +
                        //                "grid.SelectedItem.ToString() \t\t " + grid.SelectedItem.ToString() + "\n\n" +
                        //                "grid.AlternationCount.ToString() \t\t " + grid.AlternationCount.ToString() + "\n\n" +
                        //                "grid.Name.ToString() \t\t " + grid.Name.ToString() + "\n\n" +
                        //                "grid.Parent.ToString() \t\t " + grid.Parent.ToString() + "\n\n" +
                        //                "grid.SelectedItem.GetType().ToString() \t\t " + grid.SelectedItem.GetType().ToString() + "\n\n" +
                        //                "grid.SelectedIndex.GetType().ToString() \t\t " + grid.SelectedIndex.GetType().ToString() + "\n\n" +

                        //                "e.DeadCharProcessedKey.ToString() \t\t " + e.DeadCharProcessedKey.ToString() + "\n\n" +
                        //                "e.Device.Target.ToString() \t\t" + e.Device.Target.ToString() + "\n\n" +
                        //                "e.Handled.ToString() \t\t" + e.Handled.ToString() + "\n\n" +
                        //                "e.ImeProcessedKey() \t\t" + e.ImeProcessedKey.ToString() + "\n\n" +
                        //                "e.InputSource() \t\t" + e.InputSource.ToString() + "\n\n" +
                        //                "e.IsDown() \t\t" + e.IsDown.ToString() + "\n\n" +
                        //                "e.IsRepeat() \t\t" + e.IsRepeat.ToString() + "\n\n" +
                        //                "e.IsToggled() \t\t" + e.IsToggled.ToString() + "\n\n" +
                        //                "e.IsUp() \t\t" + e.IsUp.ToString() + "\n\n" +
                        //                "e.Key() \t\t" + e.Key.ToString() + "\n\n" +
                        //                "e.KeyboardDevice() \t\t" + e.KeyboardDevice.ToString() + "\n\n" +
                        //                "e.KeyStates() \t\t" + e.KeyStates.ToString() + "\n\n" +
                        //                "e.OriginalSource() \t\t" + e.OriginalSource.ToString() + "\n\n" +
                        //                "e.RoutedEvent() \t\t" + e.RoutedEvent.ToString() + "\n\n" +
                        //                "e.Source() \t\t" + e.Source.ToString() + "\n\n" +
                        //                "e.SystemKey() \t\t" + e.SystemKey.ToString() + "\n\n" +
                        //                "e.Timestamp() \t\t" + e.Timestamp.ToString() + "\n\n" +
                        //                "sender.ToString() \t\t" + sender.ToString());

                        //MessageBox.Show("DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)" + "\n\n" +
                        //                "row.GetType().ToString() \t\t " + row.GetType().ToString() + "\n\n");

                        if ((MessageBox.Show("Estás seguro?", ("Eliminar row: " + datagrid.SelectedIndex), MessageBoxButton.YesNo) == MessageBoxResult.No))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    //MessageBox.Show("Employee deleted sucessfully.", "Delete Employee", MessageBoxButton.OK, MessageBoxImage.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("else employee hasn't been deleted");
                    //}                       
                }
                else
                {
                    MessageBox.Show("No está activada la opción de eliminar");
                }
            }
        }

        public static void DataGridInsertEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            //DataGrid grid = sender as DataGrid;
            //int selectedindex = grid.SelectedIndex;
            //MessageBox.Show("DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)" + "\n\n" +
            //                "grid.SelectedItem.ToString() \t\t " + grid.SelectedItem.ToString() + "\n\n" +
            //                "grid.AlternationCount.ToString() \t\t " + grid.AlternationCount.ToString() + "\n\n" +
            //                "grid.Name.ToString() \t\t " + grid.Name.ToString() + "\n\n" +
            //                "grid.Parent.ToString() \t\t " + grid.Parent.ToString() + "\n\n" +
            //                "grid.SelectedItem.GetType().ToString() \t\t " + grid.SelectedItem.GetType().ToString() + "\n\n" +
            //                "grid.SelectedIndex.GetType().ToString() \t\t " + grid.SelectedIndex.GetType().ToString() + "\n\n" +
            //                "grid.SelectedIndex.ToString()" + "\t\t" + grid.SelectedIndex.ToString() + "\n\n" +

            //                "e.Cancel.ToString() \t\t " + e.Cancel.ToString() + "\n\n" +
            //                "e.Column.DisplayIndex.ToString() \t\t" + e.Column.DisplayIndex.ToString() + "\n\n" +
            //                "e.Column.Header.ToString() \t\t" + e.Column.Header.ToString() + "\n\n" +
            //                "e.Column.Dispatcher.ToString() \t\t" + e.Column.Dispatcher.ToString() + "\n\n" +
            //                "e.EditAction.ToString() \t\t" + e.EditAction.ToString() + "\n\n" +
            //                "e.EditingElement.ToString() \t\t" + e.EditingElement.ToString() + "\n\n" +
            //                "e.Row.Name.ToString() \t\t" + e.Row.Name.ToString() + "\n\n" +
            //                "e.Row.Item.ToString() \t\t" + e.Row.Item.ToString() + "\n\n" +
            //                "e.Row.DataContext.ToString() \t\t" + e.Row.DataContext.ToString() + "\n\n" +
            //                "e.Row.BindingGroup.ToString() \t\t" + e.Row.BindingGroup.ToString() + "\n\n" +
            //                "e.Row.AlternationIndex.ToString() \t\t" + e.Row.AlternationIndex.ToString() + "\n\n" +
            //                "e.GetType() \t\t" + e.GetType() + "\n\n" +
            //                "sender.ToString() \t\t" + sender.ToString());

            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.SelectedContent.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.SelectedContent.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.DataContext.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.DataContext.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.InputBindings.GetType().ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.InputBindings.GetType().ToString() + "\n\n");
            ////MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.ItemsSource.GetType().ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.ItemsSource.GetType().ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.Name.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.Name.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.SelectedContent.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.SelectedContent.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.SelectedIndex.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.SelectedIndex.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.SelectedItem.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.SelectedItem.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.SelectedValue.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.SelectedValue.ToString() + "\n\n");
            //MessageBox.Show("((MainWindow)Application.Current.MainWindow).tbControl.TabIndex.ToString()" + "\n" + ((MainWindow)Application.Current.MainWindow).tbControl.TabIndex.ToString());

            TabItem tabitem = ((View.MainWindow)Application.Current.MainWindow).tbControl.SelectedItem as TabItem;
            //MessageBox.Show("tabitem.Content.ToString()" + "\n" + tabitem.Content.ToString());
            //MessageBox.Show("tabitem.DataContext.ToString()" + "\n" + tabitem.DataContext.ToString());
            //MessageBox.Show("tabitem.Header.ToString()" + "\n" + tabitem.Header.ToString());
            //MessageBox.Show("tabitem.InputBindings.ToString()" + "\n" + tabitem.InputBindings.ToString());
            //MessageBox.Show("tabitem.InputBindings.GetType().ToString()" + "\n" + tabitem.InputBindings.GetType().ToString());
            ////MessageBox.Show("tabitem.InputScope.ToString()" + "\n" + tabitem.InputScope.ToString());
            ////MessageBox.Show("tabitem.InputScope.Names.ToString()" + "\n" + tabitem.InputScope.Names.ToString());
            ////MessageBox.Show("tabitem.InputScope.GetType().ToString()" + "\n" + tabitem.InputScope.GetType().ToString());
            //MessageBox.Show("tabitem.Name.ToString()" + "\n" + tabitem.Name.ToString());
            //MessageBox.Show("tabitem.Parent.ToString()" + "\n" + tabitem.Parent.ToString());
            //MessageBox.Show("tabitem.TabIndex.ToString()" + "\n" + tabitem.TabIndex.ToString());

            ////public static Dictionary<EOpcion, DatosInfoTabItem> tabitemdictionary = new Dictionary<EOpcion,DatosInfoTabItem>();
            GenericObservableCollection opcionobservablecollection = tabitemdictionary.Where(c => c.Key.ToString() == tabitem.Name.ToString()).FirstOrDefault().Value.ObsCollectionOrigin;
            //TabItem opciontabitem = tabitemdictionary.Where(c => c.Key.ToString() == tabitem.Name.ToString()).FirstOrDefault().Value.TbItem;


            foreach (var item in opcionobservablecollection.GenericObsCollection)
            {
                MessageBox.Show(item.GetType().ToString());
            }

            MessageBox.Show("DataGridInsertEdit");
        }
    }
}
