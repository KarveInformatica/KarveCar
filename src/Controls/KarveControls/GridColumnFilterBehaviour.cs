using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace KarveControls
{
    
      public  class GridColumnFilterBehaviour : Behavior<SfDataGrid>
      {
          /// <summary>
          ///  Each grid has an unique identifier.
          /// </summary>
          private SortedSet<string> _sortedSet = new SortedSet<string>();
          public static readonly DependencyProperty AssistPropertiesDependencyProperty =
              DependencyProperty.Register(
                  "AssistProperties",
                  typeof(string),
                  typeof(GridColumnFilterBehaviour),
                  new PropertyMetadata(string.Empty, OnBuildSet));

       

        private static void OnBuildSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridColumnFilterBehaviour filterBehaviour = d as GridColumnFilterBehaviour;
            if (filterBehaviour != null)
            {
                var properties = filterBehaviour.AssistProperties;
                if (!string.IsNullOrEmpty(properties))
                {
                    string[] tokens = properties.Split(',');
                    foreach (var t in tokens)
                    {
                        filterBehaviour.AddColumn(t.Trim());
                        
                    }
                }
            }
        }

        private void AddColumn(string col)
        {
            _sortedSet.Add(col);
        }

        public string AssistProperties
        {
            get { return (string)GetValue(AssistPropertiesDependencyProperty); }
            set { SetValue(AssistPropertiesDependencyProperty, value); }

        }
          protected override void OnAttached()
          {
              this.AssociatedObject.AutoGeneratingColumn +=  AssociatedObject_AutogenerateCols;
              base.OnAttached();
          }
        private void AssociatedObject_AutogenerateCols(object sender, AutoGeneratingColumnArgs e)
        {

            if (!_sortedSet.Contains(e.Column.MappingName))
            {
                e.Cancel = true;
            }
            else
            {
                // This shall not be auto.
                // https://www.syncfusion.com/forums/121547/sf-datagrid-very-slow-in-load-view
                if (this.AssociatedObject.Columns.Count == 2)
                {
                   // e.Column.Width = 150;
                  //  AssociatedObject.MaxWidth = 300;
                }
            }
        }

        protected override void OnDetaching()
          {
              AssociatedObject.AutoGeneratingColumn -= AssociatedObject_AutogenerateCols;
              base.OnDetaching();
          }

    }
}
