using KarveCar;
using KarveCar.Model.Generic;
using KarveCar.Model.Sybase;
using KarveCar.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using KarveCar.Views;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCommon.Generic.RecopilatorioEnumerations;

namespace KarveCommon.Logic.Generic
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
        public static TabItemUserControl CreateTabItem(EOpcion opcion)
        {

            TabItemUserControl tbitem = new TabItemUserControl();
                /*
            tbitem.VerticalAlignment = VerticalAlignment.Stretch;
            tbitem.HorizontalAlignment = HorizontalAlignment.Stretch;
            tbitem.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            tbitem.VerticalContentAlignment = VerticalAlignment.Stretch;
            var binding = new Binding();
            binding.IsAsync = true;
            binding.Path = new PropertyPath(ribbonbuttondictionary.FirstOrDefault(z => z.Key == opcion).Value.propertiesresources);
            binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            tbitem.Name = opcion.ToString();
            tbitem.HeaderTemplate = tbitem.FindResource("TabHeader") as DataTemplate;
            // TODO. This is no ok.
            TabControl control = (TabControl) ((MainWindow) Application.Current.MainWindow).tbControl;
          //Se añade el nuevo TabItem al TabControl, le ponemos el focus y devolvemos el nuevo TabItem
            control.Items.Add(tbitem);
            tbitem.Focus();
            */
            return tbitem;
        }

        /// <summary>
        /// Añade un UserControl al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// Se añade el EOpcion y el nuevo TabItem al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos.
        /// </summary>
        /// <param name="opcion"></param>
        public static void CreateTabItemUserControl(EOpcion opcion, object obj)
        {
            try
            {
                if (!tabitemdictionary.ContainsKey(opcion))
                {
                    //Se crea el Tabitem
                    TabItemUserControl tabitem = CreateTabItem(opcion);

                    //Se añade el EOpcion y el nuevo TabItem al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos
                    tabitemdictionary.Add(opcion, new TemplateInfoTabItem(tabitem));

                    //Se añade un nuevo UserControl al TabItem
                    tabitem.Content = obj;
                    
                    
                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    tabitemdictionary.FirstOrDefault(z => z.Key == opcion).Value.TabItem.Focus();
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

        /// <summary>
        /// Elimina el TabItem según el EOpcion recibido por param.
        /// </summary>
        /// <param name="opcion"></param>
        public static void RemoveTabItem(EOpcion opcion)
        {
            if (tabitemdictionary.ContainsKey(opcion))
            {
                TemplateInfoTabItem item = tabitemdictionary[opcion] as TemplateInfoTabItem;
                tabitemdictionary.Remove(tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Key);
             //   ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(item.TabItem);

            }           
        }
    }
}
