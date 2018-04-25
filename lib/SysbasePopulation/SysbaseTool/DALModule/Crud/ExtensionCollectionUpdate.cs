using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.Crud
{
    public static class ExtensionCollectionUpdate
    {
        /// <summary>
        ///  Update a collection.
        /// </summary>
        /// <typeparam name="Entity">Entity to map</typeparam>
        /// <typeparam name="Dto">Data transfer object to map</typeparam>
        /// <param name="value">Connection</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="t">Entity to map</param>
        /// <param name="dto">Mapped data transfer object</param>
        /// <returns></returns>
        public async static Task<bool> UpdateCollectionAsync<Entity>(this IDbConnection connection, IEnumerable<Entity> valuesForUpdating) where Entity : class
        {
            bool retValue = false;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // get the holidays for the office.
                    var values = await connection.GetAllAsync<Entity>();
                    // there are no holidays.
                    int pos = values.Count<Entity>();
                    if (pos == 0)
                    {
                        retValue = await connection.InsertAsync(valuesForUpdating) > 0;
                        return retValue;
                    }
                    else
                    {
                        // ok we do the difference
                        var setToInsert = valuesForUpdating.Except(values);
                        retValue = await connection.UpdateAsync(setToInsert);
                    }
                    scope.Complete();
                }
            }
            finally
            {
                connection.Close();
            }
            return retValue;
        }
    }
}
