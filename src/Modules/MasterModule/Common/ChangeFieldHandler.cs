using System.Collections.Generic;
using System.Data;
using KarveCommon;
using KarveCommon.Services;

namespace MasterModule.Common
{
    /// <summary>
    /// This is a change handle for handling chnages in the dataset.
    /// </summary>
    internal class ChangeFieldStrategy: IChangeHandler
    {
        private const string DatatableField = "DataTable";

        /// <summary>
        ///  This is the event manager for the change fields.
        /// </summary>
        private IEventManager _eventManager;
        // This is the event dictionary for he queries.
        private IDictionary<string, string> _viewModelQueries;

        /// <summary>
        ///  Current dataset.
        /// </summary>
        private DataSet _currentDataSet = null;
        /// <summary>
        /// Assistant data set.
        /// </summary>
        private DataSet _assistantDataSet = null;
        /// <summary>
        ///  Current data subsystem.
        /// </summary>
        private DataSubSystem _currentSubsystem;
        
        /// <summary>
        /// Change field strategy.
        /// </summary>
        /// <param name="ev">Event manager for notify the toolbar.</param>
        /// <param name="vmQueries">Dictionary of the queries.</param>
        /// <param name="subSystem">Data Subsystem.</param>
        public ChangeFieldStrategy(IEventManager ev, IDictionary<string,string> vmQueries, DataSubSystem subSystem)
        {
            _eventManager = ev;
            _viewModelQueries = vmQueries;
            
        }
        /// <summary>
        /// The value of current dataset.
        /// </summary>
        public DataSet CurrentDataSet { get => _currentDataSet; set => _currentDataSet = value; }
        /// <summary>
        /// The value of the assistant dataset.
        /// </summary>
        public DataSet AssistantDataSet { get => _assistantDataSet; set => _assistantDataSet = value; }
        /// <summary>
        /// The current subsystem.
        /// </summary>
        public DataSubSystem Subsystem { get => _currentSubsystem; set => _currentSubsystem = value; }

        /// <summary>
        /// During the insert payload.
        /// </summary>
        /// <param name="payLoad">Data payload</param>
        /// <param name="evDictionary">Dictionary for the queries.</param>
        public void OnInsert(DataPayLoad payLoad, IDictionary<string, object> evDictionary)
        {
            if (_currentDataSet == null)
                return;
            if (_assistantDataSet == null)
                return;

            payLoad.PayloadType = DataPayLoad.Type.Insert;
            payLoad.HasDataSet = true;
            payLoad.Subsystem = Subsystem;
            DataTable table = (DataTable)evDictionary[DatatableField];
            DataSetUtilities.MergeTableChanged(table, ref _currentDataSet);
            DataSetUtilities.MergeTableChanged(table, ref _assistantDataSet);
           // SqlBuilder.StripTop(ref _viewModelQueries);
            payLoad.Queries = _viewModelQueries;
            List<DataSet> setList = new List<DataSet>();
            setList.Add(_currentDataSet);
            setList.Add(_assistantDataSet);
            payLoad.SetList = setList;
            _eventManager.NotifyToolBar(payLoad);
        }

        private DataTable LookupDataTable(string tableName, DataSet set)
        {
            foreach (DataTable currentTable in CurrentDataSet.Tables)
            {
                if (currentTable.TableName == tableName)
                {
                    return currentTable;
                }
            }
            return null;
        }
        /// <summary>
        /// Action durante the update.
        /// </summary>
        /// <param name="payLoad">Data payload</param>
        /// <param name="evDictionary">Dictionary for the queries./param>

        public void OnUpdate(DataPayLoad payLoad, IDictionary<string, object> evDictionary)
        {
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDictionary = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataDictionary = evDictionary;
            DataTable table = (DataTable)evDictionary[DatatableField];
            string colName = (string)evDictionary["Field"];
            object changedValue = evDictionary["ChangedValue"];
            string tableName = table.TableName;
            DataTable tableFound = null;
            
            if (CurrentDataSet != null)
            {
                tableFound = LookupDataTable(tableName, CurrentDataSet);
                if (tableFound!=null)
                {
                    CurrentDataSet.Tables[tableName].Merge(table);
                    payLoad.HasDataSet = true;
                    payLoad.Set = CurrentDataSet;
                    _eventManager.NotifyToolBar(payLoad);
                    payLoad.Queries = _viewModelQueries;
                }
                else
                {
                    tableFound = LookupDataTable(tableName, CurrentDataSet);
                    if (tableFound!=null)
                    {
                        _assistantDataSet.Tables[tableName].Merge(table);
                        payLoad.Set = _assistantDataSet;
                        payLoad.Queries = _viewModelQueries;
                       _eventManager.NotifyToolBar(payLoad);
                    }
                }

            }
        }
    }
}
