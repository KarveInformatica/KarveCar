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

        /// <summary>
        ///  The main waindow will contain a reference to the UnityContainer.
        /// </summary>
        private IUnityContainer _container;
      
        public MainWindow()
        {
            InitializeComponent();         
            
        }
        /// <summary>
        ///  Overrides the base window show to inject unity in the main view model.
        /// </summary>
        public new void Show()
        {

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
