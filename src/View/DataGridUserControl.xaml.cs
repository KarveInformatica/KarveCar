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

        /// <summary>
        /// Proceso de delete de un valor del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

           
            DataGridMaestrosAuxiliaresLogic.DataGridDelete(sender, e);           
        }

        /// <summary>
        /// Proceso de insert/update de un valor del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataGridMaestrosAuxiliaresLogic.DataGridInsertEdit(sender, e);
        }
    }
}
