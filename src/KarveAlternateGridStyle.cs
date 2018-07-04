using Syncfusion.UI.Xaml.Grid;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KarveCar
{

    public class KarveAlternateGridStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var rowIndex = (item as DataRowBase).Index;
            if ((rowIndex % 2) == 0)
            {
                var type = App.Current.Resources["KarveCellWhiteStyle"] as Style;
                return type;
            }
            return App.Current.Resources["KarveCellGrayStyle"] as Style;
        }
    }
   
}