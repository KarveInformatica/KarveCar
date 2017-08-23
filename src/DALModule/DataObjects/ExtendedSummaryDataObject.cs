using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    class ExtendedSummaryDataObject : SupplierSummaryDataObject
    {
        public object Commercial { set; get; }
        public object Phone { set; get; }
        public object Zip { set; get; }
        public object City { set; get; }
        public object Type { set; get; }
        public object Email { set; get; }
        public object Aeat { set; get; }
        public object PaymentType { set; get; }
        public object Account { set; get; }
        public object Direction { set; get; }
        public object ExpenseAccount { set; get; }
        public object SupplierPeriod1 { set; get; }
        public object SupplierPeriod2 { set; get; }
        public object SupplierPeriod3 { set; get; }
        public object SupplierDay1 { set; get; }
        public object SupplierDay2 { set; get; }
        public object SupplierDay3 { set; get; }
        public object VacationMonth1 { set; get; }
        public object VacationMonth2 { set; get; }
        public object LastChange { set; get; }
        public object ChangedByUser { set; get; }
    }
}
 