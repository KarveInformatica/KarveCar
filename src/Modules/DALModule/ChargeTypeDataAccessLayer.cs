using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using KarveCommon.Generic;
using KarveDataAccessLayer.DataObjects;

/// <summary>
///  TODO: port this to async wait
/// </summary>
namespace KarveDataAccessLayer
{
    /// <summary>
    ///  Model or data abstraction for the kind of charging.
    /// </summary>    
    public class ChargeTypeDataAccessLayer : IPaymentDataServices
    {
        private readonly Uri uri = new Uri(@"karve://paymentdata/paymenttype");
        private ICollection<BaseAuxDataObject> _accountDataTable;
        private ISqlQueryExecutor _dataMapper;

        public ChargeTypeDataAccessLayer(ISqlQueryExecutor dataMapper)
        {
            this._dataMapper = dataMapper;
        }
        public Uri Path
        {
            get { return uri; }
        }
        private void QueryCopy(ISqlQueryExecutor mapper, out ObservableCollection<ChargeTypeObject> collection)
        {
            collection = new ObservableCollection<ChargeTypeObject>();
            /*
            ICollection<ChargeTypeObject> banks = mapper.QueryForList<ChargeTypeObject>("Auxiliares.GetAllChargeType", null);
            collection = new ObservableCollection<ChargeTypeObject>();
            foreach (var bank in banks)
            {
                collection.Add(bank);
            }
            */
        }

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
            // it might be desirable a query for table
            /*
            ICollection<OfficePerInvoiceTypeObject> invoiceTypes =
                 _dataMapper.QueryForList<OfficePerInvoiceTypeObject>("Auxiliares.GetAllInvoiceOffices", null);
            ICollection<BaseAuxDataObject> officies =
                 _dataMapper.QueryForList<BaseAuxDataObject>("Auxiliares.GetAllOfficeZonesPerInvoice", null);
                
            IDictionary<object, string> codeZone = new Dictionary<object, string>();
            DataTable officeDataTable = new DataTable();
            officeDataTable.Columns.Add(new DataColumn("Codigo", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Oficina", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Telefono", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Empresa", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Zona", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("NombreZona", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Direccion", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("CP", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Poblacion", typeof(string)));
            */
            ICollection<OfficePerInvoiceTypeObject> invoiceTypes = new List<OfficePerInvoiceTypeObject>();
            ICollection < BaseAuxDataObject> officies = new List<BaseAuxDataObject>();
            IDictionary<object, string> codeZone = new Dictionary<object, string>();
            DataTable officeDataTable = new DataTable();
            // i fetch alla the offices
            foreach (BaseAuxDataObject element in officies)
            {
                if ((element.Codigo != null) && (!codeZone.ContainsKey(element.Codigo)))
                {
                    codeZone.Add(element.Codigo, element.Nombre);
                }
            }
            // in codeZone, I have the code of the zone.
            foreach (OfficePerInvoiceTypeObject officeObj in invoiceTypes)
            {
                if ((officeObj!=null) && (officeObj.Codigo != null))
                {
                    var row = officeDataTable.NewRow();
                    row["Codigo"] = CheckNullToEmptyString(officeObj.Codigo);
                    row["Oficina"] = CheckNullToEmptyString(officeObj.Oficina);
                    row["Telefono"] = CheckNullToEmptyString(officeObj.Telefono);
                    row["Empresa"] = CheckNullToEmptyString(officeObj.Empresa);
                    row["Zona"] = CheckNullToDefaultString(officeObj.Zona);
                    if (codeZone.ContainsKey(row["Zona"]))
                    {
                        row["NombreZona"] = codeZone[row["Zona"]];
                    }
                    else
                    {
                        row["NombreZona"] = "";
                    }
                    row["Direccion"] = CheckNullToEmptyString(officeObj.Direccion);
                    row["CP"] = CheckNullToEmptyString(officeObj.CodigoPostal);
                    row["Poblacion"] = CheckNullToEmptyString(officeObj.Poblacion);
                    officeDataTable.Rows.Add(row);
                    officeDataTable.AcceptChanges();
                }
            }
            return officeDataTable;
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
        }
    }
}
