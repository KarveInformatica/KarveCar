using MasterModule.Views.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This is the part of the collection of items to be exposed into the view.
    /// </summary>

    partial class VehicleInfoViewModel
    {
        // fields for the expiration control.
        private List<UiComposedObject> listOfObject = new List<UiComposedObject>()
        {
            new UiComposedObject()
            {
                DataSourcePath1="FPago1",
                DataSourcePath2="IMPSEG1",
                DataSourcePath3="Pagado1"

            },
            new UiComposedObject()
            {
                DataSourcePath1="FPago2",
                DataSourcePath2="IMPSEG2",
                DataSourcePath3="Pagado2"
            },
            new UiComposedObject()
            {
                DataSourcePath1="FPago3",
                DataSourcePath2="IMPSEG3",
                DataSourcePath3="Pagado3"
            },
            new UiComposedObject()
            {
                DataSourcePath1="FPago4",
                DataSourcePath2="IMPSEG4",
                DataSourcePath3="Pagado4"
            }

        };


    }
}
