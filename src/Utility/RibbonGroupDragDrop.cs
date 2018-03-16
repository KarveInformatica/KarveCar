using System;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;

namespace KarveCar.Utility
{
    public class RibbonGroupDragDrop
    {
        /// <summary>
        /// Intercambia las posiciones de los RibbonGroup de un RibbonTab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void RibbonGroup_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var ribbongroup = e.Source as RibbonGroup;

                if (ribbongroup == null)
                    return;

                if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(ribbongroup, ribbongroup, DragDropEffects.All);
                }
            }
            catch (Exception)
            {
                //ErrorsGeneric.MessageError(ex);
            }
        }

        /// <summary>
        /// Intercambia las posiciones de los RibbonGroup de un RibbonTab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void RibbonGroup_Drop(object sender, DragEventArgs e)
        {
            try
            {
                var target = e.Source as RibbonGroup;
                var origin = e.Data.GetData(typeof(RibbonGroup)) as RibbonGroup;

                if (!target.Equals(origin))
                {   //Se intercambian las posiciones de los RibbonGroup de un RibbonTab
                    var ribbontab = target.Parent as RibbonTab;
                    int originIndex = ribbontab.Items.IndexOf(origin);
                    int targetIndex = ribbontab.Items.IndexOf(target);

                    ribbontab.Items.Remove(origin);
                    ribbontab.Items.Insert(targetIndex, origin);

                    ribbontab.Items.Remove(target);
                    ribbontab.Items.Insert(originIndex, target);

                    //Se guarda la nueva configuración en app.exe.config
                    //UserAndDefaultConfig.SetCurrentUserRibbonTabConfig(ribbontab);
                }
            }
            catch (Exception) { }
        }
    }
}
