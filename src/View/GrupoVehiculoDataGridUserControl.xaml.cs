using DataAccessLayer.DataObjects;
using KarveCar.ViewModel.MaestrosViewModel;
using System.Windows;
using System.Windows.Controls;

namespace KarveCar.View
{
    /// <summary>
    /// Lógica de interacción para GrupoVehiculoDataGridUserControl.xaml
    /// </summary>
    public partial class GrupoVehiculoDataGridUserControl : UserControl
    {
        public static readonly DependencyProperty GrupoVehiculoSelectedItemProperty = 
                    DependencyProperty.Register("GrupoVehiculoSelectedItem", 
                                                 typeof(GrupoVehiculoDataObject), 
                                                 typeof(GrupoVehiculoViewModel), 
                                                 new PropertyMetadata(default(DependencyProperty)));

        public GrupoVehiculoDataObject GrupoVehiculoSelectedItem
        {
            get { return (GrupoVehiculoDataObject)GetValue(GrupoVehiculoSelectedItemProperty); }
            set { SetValue(GrupoVehiculoSelectedItemProperty, value); }
        }

        public GrupoVehiculoDataGridUserControl()
        {
            InitializeComponent();
        }
    }
}