using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls
{
    /*
    class KarveGridFilter: Karve
    {
        public MainWindow()
        {
            InitializeComponent();
            this.sfGrid.ItemsSourceChanged += SfGrid_ItemsSourceChanged;
            this.sfGrid.CurrentCellEndEdit += dataGrid_CurrentCellEndEdit;
            FilterBox.TextChanged += (s, e) =>
            {
                FilterText = FilterBox.Text;
                if (sfGrid.View != null)
                    sfGrid.View.RefreshFilter();
            };
        }
        private void dataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            if (sfGrid.IsFilterRowIndex(e.RowColumnIndex.RowIndex))
            {

                MessageBox.Show("Filter ended");
            }

        }


        private void SfGrid_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e)
        {
            if (sfGrid.View != null)
            {
                sfGrid.View.Filter = FilerRecords;
                sfGrid.View.RefreshFilter();
            }
        }


    }
    */
}
