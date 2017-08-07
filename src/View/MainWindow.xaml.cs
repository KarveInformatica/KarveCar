using KarveCar.Utility;
using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using KarveCar.ViewModel;
using KarveCar.ViewModel.GenericViewModel;
using KarveCommon.Services;
using Microsoft.Practices.Unity;

namespace KarveCar.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {

        private IUnityContainer _container;
      
        public MainWindow()
        {
            InitializeComponent();         
            
        }

        public new void Show()
        {

           /* DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.stInicio.Text = "Aquí ponemos algún texto, p.e.: " + DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:ss");
                this.Title = "KarveWin  v0.1";
            }, this.Dispatcher);
            */
            //Carga la configuración personalizada del usuario (idioma y RibbonTabs/RibbonGroups). En caso que no exista configuración personalizada,
            //se cargará la configuración por defecto según app.exe.config y VariablesGlobales.ribbontabdictionary
            this.DataContext = new MainWindowViewModel(this._container);
            UserAndDefaultConfig.LoadCurrentUserRibbonTabConfig();

            base.Show();    
        }
        public IUnityContainer UnityContainer
        {
            get { return _container; }
            set { _container = value; }

        }

        public void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí va nuestro mensaje de ayuda", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region RibbonGroup Drag&Drop
        private void RibbonGroup_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            RibbonGroupDragDrop.RibbonGroup_PreviewMouseMove(sender, e);
        }

        private void RibbonGroup_Drop(object sender, DragEventArgs e)
        {
            RibbonGroupDragDrop.RibbonGroup_Drop(sender, e);
        }
        #endregion
        private void tbControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // this has to be done currently by the configuration service.
            //ToolBarLogic.EnabledDisabledToolBarButtonsByEOpcion();
        }
    }
}
