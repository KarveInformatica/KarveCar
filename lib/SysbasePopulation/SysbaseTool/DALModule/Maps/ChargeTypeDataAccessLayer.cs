using System;
using System.Collections.Generic;
using System.Data;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    ///  Model or data abstraction for the kind of charging.
    /// </summary>    
    internal class ChargeTypeDataAccessLayer : IPaymentDataServices
    {
        private readonly Uri uri = new Uri(@"karve://paymentdata/paymenttype");
     //   private ICollection<BaseAuxDataObject> _accountDataTable;
        private ISqlQueryExecutor _dataMapper;

        public ChargeTypeDataAccessLayer(ISqlQueryExecutor dataMapper)
        {
            this._dataMapper = dataMapper;
        }
        public Uri Path
        {
            get { return uri; }
        }
        /*
        private void QueryCopy(ISqlQueryExecutor mapper, out ObservableCollection<ChargeTypeObject> collection)
        {
            collection = new ObservableCollection<ChargeTypeObject>();
            ICollection<ChargeTypeObject> banks = mapper.QueryForList<ChargeTypeObject>("Auxiliares.GetAllChargeType", null);
            collection = new ObservableCollection<ChargeTypeObject>();
            foreach (var bank in banks)
            {
                collection.Add(bank);
            }
            
        }*/

        public  DataTable GetAllInvoiceTypeDataTable()
        {
            //ICollection<BaseAuxDataObject> invoiceTypes = _dataMapper.QueryForList<BaseAuxDataObject>("Auxiliares.GetAllInvoiceType", null);
            DataTable table = new DataTable();
            /*
            table.Columns.Add(new DataColumn("Codigo", typeof(string)));
            table.Columns.Add(new DataColumn("Definicion", typeof(string)));
            foreach (var item in invoiceTypes)
            {
                var row = table.NewRow();
                row["Codigo"] = item.Codigo;
                row["Definicion"] = item.Nombre;
                table.Rows.Add(row);
               // table.AcceptChanges();
            }
            */
            return table;
        }

        public string GetAccountDefinitionByCode(string inCode)
        {
            /*
            if (_accountDataTable == null)
            {
                _accountDataTable = _dataMapper.QueryForList<BaseAuxDataObject>("Auxiliares.GetAllBanksAccount", null);
            }
            foreach (var item in _accountDataTable)
            {
                string code = CheckNullToEmptyString(item.Codigo);
                string definicion = CheckNullToEmptyString(item.Nombre);
                if (String.Compare(code, inCode, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return definicion;
                }
            }
            */
            return "";
        }

        public DataTable GetAllAccountsDataTable()
        {
            DataTable table = new DataTable();

            // _accountDataTable = _dataMapper.QueryForList<BaseAuxDataObject>("Auxiliares.GetAllBanksAccount", null);

            /*DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Codigo", typeof(string)));
            table.Columns.Add(new DataColumn("Definicion", typeof(string)));
            foreach (var item in _accountDataTable)
            {
                var row = table.NewRow();
                row["Codigo"] = CheckNullToEmptyString(item.Codigo);
                row["Definicion"] = CheckNullToEmptyString(item.Nombre);
                table.Rows.Add(row);
               // table.AcceptChanges();
            }
            */
            return table;
        }

        /// <summary>
        /// This returns the charge options for the charging
        /// </summary>
        /// <param name="selectedItemCode">Value of the item to be selected in the grid</param>
        /// <returns></returns>
        public IDictionary<string, bool> GetChargeOptions(int selectedItemCode)
        {
            IDictionary<string, bool> options = new Dictionary<string, bool>();

            /*
            IDictionary<string, bool> options = new Dictionary<string, bool>();

            ICollection<ChargeOptionDataObject> invoiceTypes = _dataMapper.QueryForList<ChargeOptionDataObject>("Auxiliares.GetChargeOptions", selectedItemCode);
            foreach (ChargeOptionDataObject chargeOptionData in invoiceTypes)
            {
                options["IsCashFlowChecked"] = chargeOptionData.IsCashFlowChecked;
                options["IsClientAccountChecked"] = chargeOptionData.IsClientAccountChecked;
                options["IsNoRemittableChecked"] = chargeOptionData.IsNoRemittableChecked;
                options["IsPorfolioEffectsChecked"] = chargeOptionData.IsPorfolioEffectsChecked;
                options["IsSeatingFeeChecked"] = chargeOptionData.IsSeatingFeeChecked;
                options["IsShowerChecked"] = chargeOptionData.IsShowerChecked;
                options["IsTeleChequeChecked"] = chargeOptionData.IsTeleChequeChecked;
            }
            */
            return options;
        }

        public DataTable GetAllInvoiceOfficesDataTable()
        {
             return new DataTable();
        }

        protected string CheckNullToDefaultString(object ob)
        {
            if (ob == null)
            {
                return "0F";
            }
            string v = ob as string;
            return v;
        }

        // move to an helper class.
        protected string CheckNullToEmptyString(object ob)
        {
            if (ob == null)
            {
                return "";
            }
            string v = ob as string;
            return v;
        }

        public DataTable GetChargeObjects()
        {
            throw new NotImplementedException();
        }
        /*
public DataTable GetChargeObjects()
{
   DataTable table = new DataTable();
   ICollection<ChargeTypeObject> charges =  new List<ChargeTypeObject>(); 
       //_dataMapper.QueryForList<ChargeTypeObject>("Auxiliares.GetAllChargeType", null);
   table.Columns.Add(new DataColumn("Numero", typeof(string)));
   table.Columns.Add(new DataColumn("Nombre", typeof(string)));
   table.Columns.Add(new DataColumn("Cuenta", typeof(string)));

   foreach (ChargeTypeObject item in charges)
   {
       var row = table.NewRow();
       row["Numero"] = item.Numero;
       row["Nombre"] = item.Nombre;
       row["Cuenta"] = item.Cuenta;
       table.Rows.Add(row);
       table.AcceptChanges();
   }
   return table;
}*/
    }
}
