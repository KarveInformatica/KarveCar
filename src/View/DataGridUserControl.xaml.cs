using KarveCar.Logic.Maestros;
using System.Windows.Controls;
using System.Windows.Input;

namespace KarveCar.View
{
    /// <summary>
    /// Lógica de interacción para DataGridUserControl.xaml
    /// </summary>
    public partial class DataGridUserControl : DataGrid
    {
        public DataGridUserControl()
        {
            InitializeComponent();
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DataGridMaestrosAuxiliaresLogic.DataGridDelete(sender, e);           
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridMaestrosAuxiliaresLogic.DataGridInsertEdit(sender, e);
        }
    }
}
