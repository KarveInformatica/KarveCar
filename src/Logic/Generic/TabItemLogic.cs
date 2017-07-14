using KarveCar.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Logic.Generic
{
    public class TabItemLogic
    {
        /// <summary>
        /// Devuelve un nuevo TabItem según el tipo de auxiliar que recibe por param. Se le añade el Header, Name, Focus.
        /// Se añade el nuevo TabItem al TabControl.
        /// Se añade el Resource "ResourceLanguage" para que pueda cambiar el idioma del Header del TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static TabItem CreateTabItemDataGrid(EOpcion opcion)
        {
            TabItemUserControl tbitem = new TabItemUserControl();
            var binding = new Binding();
            binding.Path = new PropertyPath(ribbonbuttondictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.propertiesresources);
            binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            tbitem.Name = opcion.ToString();
            tbitem.HeaderTemplate = tbitem.FindResource("TabHeader") as DataTemplate;

            //Se añade el nuevo TabItem al TabControl, le ponemos el focus y devolvemos el nuevo TabItem
            ((MainWindow)Application.Current.MainWindow).tbControl.Items.Add(tbitem);
            tbitem.Focus();
            return tbitem;
        }

        /// <summary>
        /// Elimina el TabItem según el EOpcion recibido por param.
        /// </summary>
        /// <param name="opcion"></param>
        public static void RemoveTabItem(EOpcion opcion)
        {
         //Se elimina el TabItem del TabControl
           ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TabItem);
                //Se elimina el TabItem del Dictionary tabitemdictionary
           tabitemdictionary.Remove(tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Key);
            
        }
    }
}
