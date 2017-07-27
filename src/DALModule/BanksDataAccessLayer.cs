using System.Collections.Generic;
using System.Collections.ObjectModel;
using Apache.Ibatis.DataMapper;
using KarveCommon.Generic;
using System;

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

        public BanksDataAccessLayer() : base(DataAccessLayer.Constants.BanksDataUri)
        {
        }

        private void QueryCopy(IDataMapper mapper, out ObservableCollection<BankDataObject> collection)
        {
            ICollection<BankDataObject> banks = DataMapper.QueryForList<BankDataObject>("Banks.GetAllBanks", null);
            collection = new ObservableCollection<BankDataObject>();

            foreach (var bank in banks)
            {
                collection.Add((BankDataObject) bank);
            }

        }

        /// <summary>
        ///  We want to ask to the db just after an update.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<BankDataObject> GetBanks()
        {
            ObservableCollection<BankDataObject> dataCollection = new ObservableCollection<BankDataObject>();
            QueryCopy(DataMapper, out dataCollection);
            return dataCollection;
        }

        public void SetBanks(ObservableCollection<BankDataObject> banks)
        {
            IList<BankDataObject> current = new List<BankDataObject>();
            foreach (var bank in banks)
            {
                current.Add(bank);
            }
            int ret = DataMapper.Update("Banks.UpdateBanks", current);
        }

        public override GenericObservableCollection GetItems()
        {
            ObservableCollection<BankDataObject> dataCollection = new ObservableCollection<BankDataObject>();
            QueryCopy(DataMapper, out dataCollection);
            // filter repeated data
            ISet<string> collectionTemp = new SortedSet<string>();
            ObservableCollection<object> abstractCollection = new ObservableCollection<object>();
            abstractCollection = FilterCollectionDuplicates<BankDataObject>(dataCollection);
            GenericObservableCollection generic = new GenericObservableCollection();
            generic.GenericObsCollection = abstractCollection;
            return generic;
        }

        public override void SetUniqueItems(GenericObservableCollection collection)
        {
            throw new NotImplementedException();
        }

        public override bool StoreCollection<T>(ObservableCollection<T> collection)
        {
            IList<BankDataObject> current = new List<BankDataObject>();
            foreach (var bank in collection)
            {
                // ok in this case. the type safety is wrong
                BankDataObject tmpObject = bank as BankDataObject;
                current.Add(tmpObject);
            }
            int ret = DataMapper.Update("Banks.UpdateBanks", current);
            return true;
        }

        public override bool RemoveCollection<T>(ObservableCollection<T> collection)
        {
            return true;
        }
        public override void SetItems(GenericObservableCollection collection)
        {
            ObservableCollection<object> abstractCollection = collection.GenericObsCollection;
            ObservableCollection<BankDataObject> currentBanks = new ObservableCollection<BankDataObject>();

            foreach (var bank in abstractCollection)
            {
                currentBanks.Add((BankDataObject) bank);
            }
            SetBanks(currentBanks);
        }

        public override string Id
        {
            get { return _id; }
        }

        public override  Type DalType {
            set { _dalType = value; }
            get { return _dalType; }
        }
  
    }

}
