using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModule.Views
{
    /// <summary>
    ///  Columns needed 
    /// </summary>
    public partial class GridColumnsConstants
    {
        public static string BudgetMagnifierColumns = "BudgetNumber,BudgetOffice,CreationDate,DepartureDate,Group,ClientCode,Client,Reservation,Broker";
        public static string DriverMagnifierColumns = "Code,Name,Nif,Direction,Telefono,Movil,Email,CreditCardType, NumberCreditCard,AccountableAccount,Zip,City,Sector,Reseller,Oficina,Falta";
        
    }
}
