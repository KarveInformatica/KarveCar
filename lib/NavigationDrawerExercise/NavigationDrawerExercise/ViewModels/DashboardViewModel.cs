using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;


namespace NavigationDrawerExercise.ViewModels
{
    /// <summary>
    ///  This class has the respability of the main view.
    /// </summary>
    class DashboardViewModel: BindableBase
    {
        private ObservableCollection<ApplicationTile> _application;

        public DashboardViewModel()
        {

            Applications = new ObservableCollection<ApplicationTile>();
            Applications.Add(new ApplicationTile() { Name = "Proveedores", Color = "#FF4DAEB5",  Header = "Proveedores", Icon = "/Images/supplier.png", Description="Gestion de los proveedores" });
            Applications.Add(new ApplicationTile() { Name = "Vehiculos", Color = "#FF36377C", Icon = "/Images/cars.png", Header = "Vehiculos", Description = "Gestion de los vehiculos en alquiler" });
            Applications.Add(new ApplicationTile() { Name = "Clientes", Color = "#FFD68513", Icon = "/Images/clients.png", Description = "Gestion de los clientes.", Header = "Clientes" });
            Applications.Add(new ApplicationTile() { Name = "Comisionistas", Color = "#FFD68513", Icon = "/Images/brokers.png", Description = "Gestion de los comisionistas.", Header = "Comisionistas" });
            Applications.Add(new ApplicationTile() { Name = "Tarifa", Color = "#FFD68513", Icon = "/Images/fare.png", Description = "Gestion de las tarifas", Header = "Tarifas" });
            Applications.Add(new ApplicationTile() { Name = "Empresas", Color = "green", Icon = "/Images/company.png", Description = "Gestion Auxiliares.", Header = "Empresas" });
            Applications.Add(new ApplicationTile() { Name = "Oficinas", Color = "Blue", Icon = "/Images/office.png", Description = "Gestion Oficinas", Header = "Oficinas" });
            Applications.Add(new ApplicationTile() { Name = "Facturas", Color = "#FFD68523", Icon = "/Images/billing.png", Description = "Gestion de las facturas.", Header = "Facturas" });
            Applications.Add(new ApplicationTile() { Name = "Contractos", Color = "CadetBlue", Icon = "/Images/contract.png", Description = "Gestion Contractos.", Header = "Contractos" });
            Applications.Add(new ApplicationTile() { Name = "Reservas", Color = "#FFD88523", Icon = "/Images/booking.png", Description = "Gestion Reservas.", Header = "Reservas" });
            Applications.Add(new ApplicationTile() { Name = "Impostaciones", Color = "#FF4DAEB5", Icon = "/Images/settings.png", Description = "Impostaciones Applicacion", Header = "Impostaciones" });

            Applications.Add(new ApplicationTile() { Name = "Auxiliares", Color = "Cyan", Icon = "/Images/helpers.png", Description = "Gestion Auxiliares.", Header = "Auxiliares" });

        }
        public ObservableCollection<ApplicationTile> Applications
        {
            set
            {
                _application = value;
                RaisePropertyChanged("Applications");
            }
            get
            {
                return _application;
            }
        }

    }
}
