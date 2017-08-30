﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  common interface for the 
    /// </summary>
    public interface ISupplierDataServices
    {
      
        #region Asynchronous methods
        /// <summary>
        ///  Returns the dataset in asynchronous way for all suppliers.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllSupplierSummary();
        /// <summary>
        /// This retrives the data supplier type for a given data object
        /// </summary>
        /// <param name="id"> data object id.</param>
        /// <returns></returns>
        Task<ISupplierTypeData> GetAsyncSupplierTypesDataObject(string id);
        /// <summary>
        /// This retrives the data object info for a given data object
        /// </summary>
        /// <param name="id"> data object id.</param>
        /// <returns></returns>
        Task<ISupplierDataInfo> GetAsyncSupplierDataObjectInfo(string id);
        /// <summary>
        /// This retrives all complete summary from proveedores from provve1 and provve2.
        /// </summary>
        /// <returns>Returns a dataset from complete summary.</returns>
        Task<DataSet> GetAsyncCompleteSummary();
        /// <summary>
        /// This returns all async provider types.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllProviderTypes();
        Task<ISupplierEvaluationNoteData> GetAsyncSupplierEvaluationNoteDataObject(string supplierId);
        Task<ISupplierMonitoringData> GetAsyncMonitoringSupplierById(string id);
        ISupplierTypeData GetAsyncSupplierTypeById(string id);
        Task<DataSet> GetAsyncSuppliersSummaryPaged();
        void UpdateDataObject(object dataObject);
        void UpdateDataSet(DataSet set);
        void InsertDataObject(object dataObject);
        void InsertDataSet(DataSet set);


        #endregion
    }
}
