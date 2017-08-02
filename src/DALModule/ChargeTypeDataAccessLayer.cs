using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ibatis.DataMapper;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    ///  Model or data abstraction for the kind of charging.
    /// </summary>
    /// <remarks>Depends on BankDataAccessLayer</remarks>

    public class ChargeTypeDataAccessLayer : BaseDataMapper
    {
        private readonly string _id = "ChargeTypeDAL";
        private Type _dalType = typeof(ChargeTypeObject);
        // logical a component shall not depende on other one the same level.
        private BanksDataAccessLayer banksDataAccessLayer = new BanksDataAccessLayer();
        /// <summary>
        ///  This dal object is useful for accessing to the different types of charging
        /// </summary>
        public ChargeTypeDataAccessLayer()
        {
            base.Id = _id;
        }
        /// <summary>
        ///  This returns the types of charging
        /// </summary>
        /// <returns>A list of observable</returns>
        public override GenericObservableCollection GetItems()
        {
            ObservableCollection<ChargeTypeObject> dataCollection = new ObservableCollection<ChargeTypeObject>();
            QueryCopy(DataMapper, out dataCollection);
            GenericObservableCollection obs = new GenericObservableCollection();
            ObservableCollection<object> newCollection = new ObservableCollection<object>();
            foreach (var item in dataCollection)
            {
                newCollection.Add(item);
            }
            obs.GenericObsCollection = newCollection;
            return obs;
        }
        private void QueryCopy(IDataMapper mapper, out ObservableCollection<ChargeTypeObject> collection)
        {
            ICollection<ChargeTypeObject> banks = DataMapper.QueryForList<ChargeTypeObject>("Auxiliares.GetAllChargeType", null);
            collection = new ObservableCollection<ChargeTypeObject>();
            foreach (var bank in banks)
            {
                collection.Add(bank);
            }
        }
        public DataTable GetAllInvoiceTypeDataTable()
        {
            ICollection<BaseAuxDataObject> invoiceTypes = DataMapper.QueryForList<BaseAuxDataObject>("Auxiliares.GetAllInvoiceType", null);
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Codigo", typeof(long)));
            table.Columns.Add(new DataColumn("Nombre", typeof(string)));
            foreach (var item in invoiceTypes)
            {
                var row = table.NewRow();
                row["Codigo"] = item.Codigo;
                row["Nombre"] = item.Nombre;
                table.Rows.Add(row);
            }
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
            ICollection<ChargeOptionDataObject> invoiceTypes = DataMapper.QueryForList<ChargeOptionDataObject>("Auxiliares.GetChargeOptions", selectedItemCode);
            foreach (ChargeOptionDataObject chargeOptionData in invoiceTypes)
            {
                options["IsCacheFlowChecked"] = chargeOptionData.IsCashFlowChecked;
                options["IsClientAccountChecked"] = chargeOptionData.IsClientAccountChecked;
                options["IsNoRemittableChecked"] = chargeOptionData.IsNoRemittableChecked;
                options["IsPorfolioEffectsChecked"] = chargeOptionData.IsPorfolioEffectsChecked;
                options["IsSeatingFeeChecked"] = chargeOptionData.IsSeatingFeeChecked;
                options["IsShowerChecked"] = chargeOptionData.IsShowerChecked;
                options["IsTeleChequeChecked"] = chargeOptionData.IsTeleChequeChecked;
            }
            return options;
        }

        public DataTable GetAllInvoiceOfficesDataTable()
        {
            ICollection<OfficePerInvoiceTypeObject> invoiceTypes =
                DataMapper.QueryForList<OfficePerInvoiceTypeObject>("Auxiliares.GetAllInvoiceOffices", null);
            ICollection<BaseAuxDataObject> officies =
                DataMapper.QueryForList<BaseAuxDataObject>("Auxiliares.GetAllOfficeZonesPerInvoice", null);
            IDictionary<object, string> codeZone = new Dictionary<object, string>();
            DataTable officeDataTable = new DataTable();
            officeDataTable.Columns.Add(new DataColumn("Codigo", typeof(long)));
            officeDataTable.Columns.Add(new DataColumn("Oficina", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Telefono", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Empresa", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("Zona", typeof(string)));
            officeDataTable.Columns.Add(new DataColumn("NombreZona", typeof(string)));
            // i fetch alla the offices
            foreach (BaseAuxDataObject element in officies)
            {
                codeZone.Add(element.Codigo, element.Nombre);
            }
            // in codeZone, I have the code of the zone.
            foreach (OfficePerInvoiceTypeObject officeObj in invoiceTypes)
            {
                var row = officeDataTable.NewRow();
                row["Codigo"] = officeObj.Codigo;
                row["Oficina"] = officeObj.Codigo;
                row["Telefono"] = officeObj.Codigo;
                row["Empresa"] = officeObj.Codigo;
                row["Zona"] = officeObj.Codigo;
                if (codeZone.ContainsKey(officeObj.Zona))
                {
                    row["NombreZona"] = officeObj.Zona;
                }
                else
                {
                    row["NombreZona"] = "";
                }
                row["Direccion"] = officeObj.Direccion;
                row["CP"] = officeObj.CodigoPostal;
                row["Poblacion"] = officeObj.Poblacion;
                officeDataTable.Rows.Add(row);
            }
            return officeDataTable;
        }
        public DataTable GetChargeObjects()
        {
            DataTable table = new DataTable();
            ICollection<ChargeTypeObject> charges = DataMapper.QueryForList<ChargeTypeObject>("Auxiliares.GetAllChargeType", null);
            table.Columns.Add(new DataColumn("Numero", typeof(long)));
            table.Columns.Add(new DataColumn("Nombre", typeof(string)));
            foreach (ChargeTypeObject item in charges)
            {
                var row = table.NewRow();
                row["Numero"] = item.Numero;
                row["Nombre"] = item.Nombre;
                table.Rows.Add(row);
            }
            return table;
        }

        public override void SetItems(GenericObservableCollection collection)
        {
            throw new NotImplementedException();
        }

        public override void StoreCollection<T>(ObservableCollection<T> collection)
        {
            throw new NotImplementedException();
        }

        public override void RemoveCollection<T>(ObservableCollection<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}
