using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveControls.KarveGrid.Column
{
    class Columns: DependencyObject
    {
        public static readonly DependencyProperty ColumnNamesDependencyProperty = DependencyProperty.RegisterAttached(
            "ColumnNames",
            typeof(string),
            typeof(Columns),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsRender)
        );
        public static void SetColumnNames(UIElement element, string value)
        {
            element.SetValue(ColumnNamesDependencyProperty, value);
        }
        public static Boolean GetIsBubbleSource(UIElement element)
        {
            return (Boolean)element.GetValue(ColumnNamesDependencyProperty);
        }

    }
}
