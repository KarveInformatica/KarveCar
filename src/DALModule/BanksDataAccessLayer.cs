using Apache.Ibatis.DataMapper;
using KarveCommon.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// A DAL class for managing the lifecycle of Banks objects. This DAL implementation
    /// uses a DataSet for persisting to the database.
    /// </summary>
    public class BanksDataAccessLayer : BaseDataMapper
    {
        private readonly string _id = RecopilatorioEnumerations.EOpcion.rbtnBancosClientes.ToString();
        private Type _dalType = typeof(BancoDataObject);
        /// <summary>
        ///  This method queries the data mapper and return an observable collection.
        /// </summary>
        /// <param name="mapper"> DataMapper value </param>
        /// <param name="collection">Collection to be filled in output</param>
        private void QueryCopy(IDataMapper mapper, out ObservableCollection<BancoDataObject> collection)
        {
            ICollection<BancoDataObject> banks = DataMapper.QueryForList<BancoDataObject>("Auxiliares.GetAllBanks", null);
            collection = new ObservableCollection<BancoDataObject>();
            foreach (var bank in banks)
            {
                collection.Add(bank);
            }

        }
        /// <summary>
        ///  Get an observable collection of banks.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<BancoDataObject> GetBanks()
        {
            ObservableCollection<BancoDataObject> dataCollection = new ObservableCollection<BancoDataObject>();
            QueryCopy(DataMapper, out dataCollection);
            return dataCollection;
        }
        /// <summary>
        ///  This replace the banks.
        /// </summary>
        /// <param name="banks"></param>
        public void ReplaceItems(ObservableCollection<BancoDataObject> banks)
        {
            /*
            foreach (BancoDataObject item in banks)
            {
                item.Codigo
            }
            */
        }
        /// <summary>
        /// For each item in the collection bank. It does an update.
        /// </summary>
        /// <param name="banks"></param>
        public void UpdateBanks(ObservableCollection<BancoDataObject> banks)
        {
            IList<BancoDataObject> current = new List<BancoDataObject>();
            foreach (var bank in banks)
            {
                current.Add(bank);
            }
            int ret = DataMapper.Update("Auxiliares.UpdateBanks", current);
        }
        /// <summary>
        ///  This returns the number of items of an observable collection.
        /// </summary>
        /// <returns></returns>
        public override GenericObservableCollection GetItems()
        {
            ObservableCollection<BancoDataObject> dataCollection = new ObservableCollection<BancoDataObject>();
            QueryCopy(DataMapper, out dataCollection);
            // filter repeated data
            ISet<string> collectionTemp = new SortedSet<string>();
            ObservableCollection<object> abstractCollection = new ObservableCollection<object>();
            GenericObservableCollection generic = new GenericObservableCollection();
            generic.GenericObsCollection = abstractCollection;
            return generic;
        }


        public override bool StoreCollection<T>(ObservableCollection<T> collection)
        {
            IList<BancoDataObject> current = new List<BancoDataObject>();
            foreach (var bank in collection)
            {
                // ok in this case. the type safety is wrong
                BancoDataObject tmpObject = bank as BancoDataObject;
                current.Add(tmpObject);
            }
            base.StoreCollection<BancoDataObject>("Auxiliares.UpdateBanks", current);
            return true;
        }

        public override bool RemoveCollection<T>(ObservableCollection<T> collection)
        {
            IList<BancoDataObject> current = new List<BancoDataObject>();
            foreach (var bank in collection)
            {
                // ok in this case. the type safety is wrong
                BancoDataObject tmpObject = bank as BancoDataObject;
                current.Add(tmpObject);
            }
            base.StoreCollection<BancoDataObject>("Auxiliares.UpdateBanks", current);
            return true;
        }
        public override void SetItems(GenericObservableCollection collection)
        {
            ObservableCollection<object> abstractCollection = collection.GenericObsCollection;
            StoreCollection(abstractCollection);
        }
    }

}
