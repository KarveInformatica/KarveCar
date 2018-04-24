using System;
using System.Windows;
using System.Windows.Controls;
using MasterModule.Interfaces;

namespace MasterModule.Views
{
    /// <summary>
    /// Lógica de interacción para ProvidersControl.xaml
    /// </summary>
    public partial class ProvidersControl : UserControl, IProvidersView
    {
        public ProvidersControl()
        {
            try
            {
                InitializeComponent();
            } catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
        }

        public string Header
        {
            get { return "Proveedores"; }
        }

    }
}
