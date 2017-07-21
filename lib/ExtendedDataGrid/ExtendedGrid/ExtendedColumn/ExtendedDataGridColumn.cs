using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ExtendedGrid.Classes;
using ExtendedGrid.ExtendedGridControl;
using ExtendedGrid.Interface;


namespace ExtendedGrid.ExtendedColumn
{
    public class ExtendedDataGridBoundColumn : DataGridBoundColumn, IExtendedColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            return null;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            return null;
          
        }

        public SummaryColumnSettings SummaryColumnSettings
        {
            get { return (SummaryColumnSettings)GetValue(SummaryColumnSettingsProperty); }
            set
            {
                SetValue(SummaryColumnSettingsProperty, value);

            }
        }

        public static readonly DependencyProperty SummaryColumnSettingsProperty = DependencyProperty.Register(
           "SummaryColumnSettings", typeof(SummaryColumnSettings), typeof(ExtendedDataGrid), new PropertyMetadata(new SummaryColumnSettings()));

        #region "Attached Properties"

        public Boolean AllowAutoFilter
        {
            get { return (Boolean)GetValue(AllowAutoFilterProperty); }
            set
            {
                SetValue(AllowAutoFilterProperty, value);

            }
        }
        public static readonly DependencyProperty AllowAutoFilterProperty = DependencyProperty.Register(
          "AllowAutoFilter", typeof(Boolean), typeof(ExtendedDataGrid), new PropertyMetadata(true));

        #endregion


        public bool HasAutoFilter
        {
            get
            {
                var grid = FindControls.FindParent<ExtendedDataGrid>(this);
                var header = FindControls.GetColumnHeaderFromColumn(this, grid);
                if (header != null)
                {
                    var popUp = FindControls.FindChild<Popup>(header, "popupDrag");
                    if (popUp != null)
                    {
                        return Convert.ToString(popUp.Tag) == "True";
                    }
                }
                return false;
            }
        }
    }
}
