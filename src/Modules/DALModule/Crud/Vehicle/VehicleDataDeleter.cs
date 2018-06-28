using DataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Crud.Vehicle
{
    class VehicleDataDeleter : IDataDeleter<IVehicleData>
    {
        private ISqlExecutor _sqlExecutor;
        public VehicleDataDeleter(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PICTURES> CollectPictures(IEnumerable<PictureDto> picturesDto)
        {
            var pic = new List<PICTURES>();
            foreach (var currentPic in picturesDto)
            {
                var simplePic = new PICTURES();
                simplePic.CODIGO = currentPic.CODIGO;
                pic.Add(simplePic);
            }
            return pic;
        }
        public async Task<bool> DeleteAsync(IVehicleData data)
        {
            bool retValue = true;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope transactionScope =
                    new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {       
                        // delete all pictures.
                        var pics = CollectPictures(data.PicturesDtos);
                        if (pics != null)
                        {
                            retValue = await connection.DeleteCollectionAsync(pics).ConfigureAwait(false);
                        }
                        VEHICULO1 vehiculo1 = new VEHICULO1();
                        vehiculo1.CODIINT = data.Value.CODIINT;
                        VEHICULO2 vehiculo2 = new VEHICULO2();
                        vehiculo2.CODIINT = data.Value.CODIINT;
                        retValue = await connection.DeleteAsync<VEHICULO1>(vehiculo1).ConfigureAwait(false);
                        if (retValue)
                        {
                            retValue = await connection.DeleteAsync<VEHICULO2>(vehiculo2).ConfigureAwait(false);
                        }
                        transactionScope.Complete();
                    }
                    catch (System.Exception e)
                    {
                        return false;
                    }
                }
            }
            return retValue;
        }
    }
}
