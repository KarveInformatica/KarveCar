using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using ExtendedGrid.Classes;
using ExtendedGrid.Converter;
using ExtendedGrid.ExtendedGridControl;

namespace ExtendedGrid.Base
{
    public class CustomDg : DataGrid
    {
        #region Constructors

        static CustomDg()
        {
        }

        public CustomDg()
        {
            Loaded += CustomDataGridLoaded;
        }

        private void CustomDataGridLoaded(object sender, RoutedEventArgs e)
        {
            var panel = Helper.GetVisualChild<CustomDataGridRowsPresenter>(this);
            if (panel != null)
                panel.InvalidateArrange();
            var extendedDataGrid = this as ExtendedDataGrid;
            if (extendedDataGrid != null && extendedDataGrid.FrozenRowCount != 0)
            {
                PropertyMetadata style = DefaultStyleKeyProperty.GetMetadata(typeof (CustomDg));
                Type ownerType = typeof (CustomDg);
                if (((Type) (style.DefaultValue)).Name == "DataGrid")
                {
                    DefaultStyleKeyProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(ownerType));
                }

                style = ItemsPanelProperty.GetMetadata(ownerType);

                if (((FrameworkTemplate) (style.DefaultValue)).VisualTree.Type != typeof (CustomDataGridRowsPresenter))
                {
                    ItemsPanelProperty.OverrideMetadata(ownerType,
                                                        new FrameworkPropertyMetadata(
                                                            new ItemsPanelTemplate(
                                                                new FrameworkElementFactory(
                                                                    typeof (CustomDataGridRowsPresenter)))));
                }
            }
            if (panel != null)
                panel.InvalidateArrange();
        }

        #endregion

        #region Frozen Rows

        /// <summary>
        /// Dependency Property fro FrozenRowCount Property
        /// </summary>
        public static readonly DependencyProperty FrozenRowCountProperty =
            DependencyProperty.Register("FrozenRowCount",
                                        typeof (int),
                                        typeof (DataGrid),
                                        new FrameworkPropertyMetadata(0,
                                                                      OnFrozenRowCountPropertyChanged,
                                                                      OnCoerceFrozenRowCount),
                                        ValidateFrozenRowCount);

        /// <summary>
        /// Property which determines the number of rows which are frozen from 
        /// the beginning in order of display
        /// </summary>
        /// 
        private bool _problemWithFrozenRowCount;

        public int? FrozenRowCount
        {
            get { return (int) GetValue(FrozenRowCountProperty); }
            set
            {
                if ((EnableColumnVirtualization || EnableRowVirtualization) && value != null)
                {
                 
                    if (_problemWithFrozenRowCount)
                        return;
                    _problemWithFrozenRowCount = true;
                    throw new Exception(
                        "Both EnableColumnVirtualization and EnableRowVirtualization should be set to False to use frozen rows.");
                }

                var cvs = CollectionViewSource.GetDefaultView(ItemsSource);
              if(  cvs.GroupDescriptions.Count>0)
              {
                  if (_problemWithFrozenRowCount)
                      return;
                  _problemWithFrozenRowCount = true;
                  throw new Exception(
                      "FrozenRowsCount cannot be set if grouping is applied.");
              }

                SetValue(FrozenRowCountProperty, value);
               if(RowSplitter!=null)
               {
                   if(value<=0)
                   {
                       RowSplitter.Visibility = Visibility.Collapsed;
                   }
                   var converter = new FrozenRowSplitterMarginConverter();
                   var values=new object[]{NonFrozenRowsViewportVerticalOffset,this};
                   RowSplitter.Margin = (Thickness)converter.Convert(values, null, null, null);
               }
            }
        }

        /// <summary>
        /// Coercion call back for FrozenRowCount property, which ensures that 
        /// it is never more that Item count
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object OnCoerceFrozenRowCount(DependencyObject d, object baseValue)
        {
            var dataGrid = (DataGrid) d;
            var frozenRowCount = (int) baseValue;

            if (frozenRowCount > dataGrid.Items.Count)
            {
                return dataGrid.Items.Count;
            }
            return baseValue;
        }

        public Rectangle RowSplitter { get; set; }

        /// <summary>
        /// Property changed callback fro FrozenRowCount
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnFrozenRowCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var extendedDataGrid = d as ExtendedDataGrid;
            if (extendedDataGrid != null && extendedDataGrid.FrozenRowCount == 0)
            {
                return;
            }

            var panel = Helper.GetVisualChild<CustomDataGridRowsPresenter>(d as Visual);
            if (panel != null)
            {
                panel.InvalidateArrange();
            }
            else
            {
                PropertyMetadata style = DefaultStyleKeyProperty.GetMetadata(typeof (CustomDg));
                Type ownerType = typeof (CustomDg);
                if (((Type) (style.DefaultValue)).Name == "DataGrid")
                {
                    DefaultStyleKeyProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(ownerType));
                }

                style = ItemsPanelProperty.GetMetadata(ownerType);

                if (((FrameworkTemplate) (style.DefaultValue)).VisualTree.Type != typeof (CustomDataGridRowsPresenter))
                {
                    ItemsPanelProperty.OverrideMetadata(ownerType,
                                                        new FrameworkPropertyMetadata(
                                                            new ItemsPanelTemplate(
                                                                new FrameworkElementFactory(
                                                                    typeof (CustomDataGridRowsPresenter)))));
                }
                panel = Helper.GetVisualChild<CustomDataGridRowsPresenter>(d as Visual);
                if (panel != null)
                {
                    panel.InvalidateArrange();
                }
            }
            var dataGrid = d as DataGrid;
            if (dataGrid != null)
            {
                try
                {
                    dataGrid.UpdateLayout();
                }
                catch
                {
                  
                }
            }
              
            if (panel != null)
            {
                panel.InvalidateArrange();
            }
        }

        /// <summary>
        /// Validation call back for frozen row count
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool ValidateFrozenRowCount(object value)
        {
            var frozenCount = (int) value;
            return (frozenCount >= 0);
        }

        /// <summary>
        /// Dependency Property key for NonFrozenColumnsViewportHorizontalOffset Property
        /// </summary>
        private static readonly DependencyPropertyKey NonFrozenRowsViewportVerticalOffsetPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "NonFrozenRowsViewportVerticalOffset",
                typeof (double),
                typeof (DataGrid),
                new FrameworkPropertyMetadata(0.0));

        /// <summary>
        /// Dependency property for NonFrozenRowsViewportVerticalOffset Property
        /// </summary>
        public static readonly DependencyProperty NonFrozenRowsViewportVerticalOffsetProperty =
            NonFrozenRowsViewportVerticalOffsetPropertyKey.DependencyProperty;

        /// <summary>
        /// Property which gets/sets the start y coordinate of non frozen rows in view port
        /// </summary>
        public double NonFrozenRowsViewportVerticalOffset
        {
            get {
                if (RowSplitter != null)
                {
                    if (FrozenRowCount <= 0)
                    {
                        RowSplitter.Visibility = Visibility.Collapsed;
                    }
                    var converter = new FrozenRowSplitterMarginConverter();
                    var values = new object[] { (double) GetValue(NonFrozenRowsViewportVerticalOffsetProperty), this };
                    RowSplitter.Margin=(Thickness) converter.Convert(values, null, null, null);
                }
                return (double) GetValue(NonFrozenRowsViewportVerticalOffsetProperty); 
            }
            internal set
            {
                SetValue(NonFrozenRowsViewportVerticalOffsetPropertyKey, value);
                if (RowSplitter != null)
                {
                    if (FrozenRowCount <= 0)
                    {
                        RowSplitter.Visibility = Visibility.Collapsed;
                    }
                    var converter = new FrozenRowSplitterMarginConverter();
                    var values = new object[] { (double) GetValue(NonFrozenRowsViewportVerticalOffsetProperty), this };
                    RowSplitter.Margin = (Thickness)converter.Convert(values, null, null, null);
                }
            }
        }

        /// <summary>
        /// Method which gets called when Vertical scroll occurs on the scroll viewer of datagrid.
        /// Forwards the call to rows and header presenter.
        /// </summary>
        internal void OnVerticalScroll()
        {
            var panel = Helper.GetVisualChild<CustomDataGridRowsPresenter>(this);
            panel.InvalidateArrange();
        }

        #endregion
    }
}
