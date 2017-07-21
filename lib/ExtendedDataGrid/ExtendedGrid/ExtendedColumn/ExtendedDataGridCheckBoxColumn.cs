using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ExtendedGrid.Classes;
using ExtendedGrid.ExtendedGridControl;
using ExtendedGrid.Interface;

namespace ExtendedGrid.ExtendedColumn
{
    public class ExtendedDataGridCheckBoxColumn : DataGridCheckBoxColumn, IExtendedColumn
    {

        #region Members



        #endregion

        #region "Attached Properties"

        public Boolean AllowAutoFilter
        {
            get { return (Boolean)GetValue(AllowAutoFilterProperty); }
            set
            {
                SetValue(AllowAutoFilterProperty, value);

            }
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
           "SummaryColumnSettings", typeof(SummaryColumnSettings), typeof(ExtendedDataGridCheckBoxColumn));

        public static readonly DependencyProperty AllowAutoFilterProperty = DependencyProperty.Register(
          "AllowAutoFilter", typeof(Boolean), typeof(ExtendedDataGridCheckBoxColumn), new PropertyMetadata(true));

        #endregion

        #region Properties

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

        #endregion


    }
}
