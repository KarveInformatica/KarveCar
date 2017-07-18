using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Apache.Ibatis.DataMapper;
using KarveCar.Common;
using KarveCommon.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// A DAL class for managing the lifecycle of Banks objects. This DAL implementation
    /// uses a DataSet for persisting to the database.
    /// </summary>
    public class BanksDataAccessLayer : BaseDataMapper
    {
        private readonly string _id = Maestro.rbtnBancosClientes.ToString();
        private Type _dalType = typeof(BankDataObject);
        private ObservableCollection<BankDataObject> cachedCollection = null;

        public BanksDataAccessLayer(): base(DataAccessLayer.Constants.BanksDataUri)
        {
        }

        private void QueryCopy(IDataMapper mapper, out ObservableCollection<BankDataObject> collection)
        {
            ICollection <BankDataObject> banks = DataMapper.QueryForList<BankDataObject>("Banks.GetAllBanks", null);
            collection = new ObservableCollection<BankDataObject>();

            foreach (var bank in banks)
            {
                collection.Add((BankDataObject)bank);
            }

        }
        /// <summary>
        ///  We want to ask to the db just after an update.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<BankDataObject> GetBanks()
        {
            if (cachedCollection == null)
            {
                cachedCollection = new ObservableCollection<BankDataObject>();
                QueryCopy(DataMapper, out cachedCollection);
            }
            return cachedCollection;
        }
        public void SetBanks(ObservableCollection<BankDataObject> banks)
        {
            cachedCollection = null;
            IList<BankDataObject> current = new List<BankDataObject>();
            foreach (var bank in banks)
            {
                current.Add(bank);
            }
            int ret = DataMapper.Update("Banks.UpdateBanks", current);
        }

        public override GenericObservableCollection GetItems()
        {
            if (cachedCollection == null)
            {
                cachedCollection = new ObservableCollection<BankDataObject>();
                QueryCopy(DataMapper, out cachedCollection);
            }
            ObservableCollection<object> abstractCollection = new ObservableCollection<object>();
            foreach (var bank in cachedCollection)
            {
                abstractCollection.Add((object)bank);
            }
            GenericObservableCollection generic = new GenericObservableCollection();
            generic.GenericObsCollection = abstractCollection;
            return generic;
        }

        public override void SetUniqueItems(GenericObservableCollection collection)
        {
            throw new NotImplementedException();
        }
        public override void SetItems(GenericObservableCollection collection)
        {
            ObservableCollection<object> abstractCollection = collection.GenericObsCollection;
            ObservableCollection<BankDataObject> currentBanks = new ObservableCollection<BankDataObject>();

            foreach (var bank in abstractCollection)
            {
                currentBanks.Add((BankDataObject)bank);
            }
            SetBanks(currentBanks);
        }

        public override string Id { get => _id; }
        public override  Type DalType { get => _dalType; set => _dalType = value; }
    }

}
