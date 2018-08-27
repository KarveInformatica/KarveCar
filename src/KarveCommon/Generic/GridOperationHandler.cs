using System;
using KarveDataServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using KarveDataServices.ViewObjects;
using System.Linq;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  GridOperationHandler. The grid operation handler has the responsa
    /// </summary>
    /// <typeparam name="DtoType"></typeparam>
    public class GridOperationHandler<DtoType> where DtoType : class
    {
        private IDataServices _dataService;
        private IHelperDataServices _helperDataServices;
        /// <summary>
        ///  GridOperationHandler.
        /// </summary>
        /// <param name="service"></param>
        public GridOperationHandler(IDataServices service)
        {
            _dataService = service;
            _helperDataServices = _dataService.GetHelperDataServices();
        }
        /// <summary>
        ///  ExecuteInsertAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task ExecuteInsertAsync<T>(object sender) where T : class
        {
            IEnumerable<DtoType> dtoValues = sender as IEnumerable<DtoType>;
            var retValue = false;
            try
            {
                if (dtoValues != null)
                {

                    var newItems = dtoValues.Where(x =>
                    {
                        BaseViewObject baseViewObject = x as BaseViewObject;
                        return (baseViewObject.IsNew == true);
                    }
                        );
                    if (newItems.Count() > 0)
                    {
                        retValue = await _helperDataServices.ExecuteBulkInsertAsync<DtoType, T>(newItems).ConfigureAwait(false);

                    }

                }
            } catch (Exception ex)
            {
                throw new DataLayerException(ex.Message, ex);
            }
            
        }
        /// <summary>
        /// Execute a delete of a grid.
        /// </summary>
        /// <typeparam name="T">Type to delete</typeparam>
        /// <param name="sender">Sender of the grid</param>
        /// <returns></returns>
        public async Task<bool> ExecuteDeleteAsync<T>(object sender) where T : class
        {
            IEnumerable<DtoType> dtoValues = sender as IEnumerable<DtoType>;
            bool retValue = false;
            if (dtoValues!=null)
            {
                var newItems = dtoValues.Where(x =>
                {
                    BaseViewObject baseViewObject = x as BaseViewObject;
                    return (baseViewObject.IsDeleted == true);
                });
                if (dtoValues.Count() > 0)
                { 
                    retValue = await _helperDataServices.ExecuteBulkDeleteAsync<DtoType, T>(dtoValues).ConfigureAwait(false);
                }
            }
            return retValue;
        }
        /// <summary>
        /// Execute the update async. 
        /// </summary>
        /// <typeparam name="T">entity Type.</typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteUpdateAsync<T>(object sender) where T : class
        {
            IEnumerable<DtoType> dtoValues = sender as IEnumerable<DtoType>;
            bool retValue = false;
            if (dtoValues != null)
            {
                var newItems = dtoValues.Where(x =>
                {
                    BaseViewObject baseViewObject = x as BaseViewObject;
                    return ((baseViewObject.IsDirty == true) && (!baseViewObject.IsNew));
                });
                if (dtoValues.Count() > 0)
                {
                    retValue = await _helperDataServices.ExecuteBulkUpdateAsync<DtoType,T>(newItems).ConfigureAwait(false);
                }
            }
            return retValue;
        }
    }

}