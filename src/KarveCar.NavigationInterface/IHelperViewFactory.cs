using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Navigation
{
    public interface IHelperViewFactory
    {
        void NewOriginView(Uri uri);
        void NewBookingMediaView(Uri uri);
        void NewBookingTypeView(Uri uri);
        void NewEmployeeAgencyView(Uri uri);
        void NewContactClientView(Uri uri);
        void NewPaymentFormView(Uri uri);
        void NewVehicleActivityView(Uri uri);
        void NewBookingPrintingType(Uri uri);
        void NewReseller(Uri uri);
        void NewBookingRequestReason(Uri uri);
    }
}
