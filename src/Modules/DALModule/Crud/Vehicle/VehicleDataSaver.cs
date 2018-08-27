using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using DataAccessLayer.Logic;
using AutoMapper;
using DataAccessLayer.DataObjects;
using Model;
using KarveDataServices.ViewObjects;
using System.Data;
using System.Transactions;
using Dapper;
using KarveDapper;
using KarveDapper.Extensions;


namespace DataAccessLayer.Crud.Vehicle
{
    class VehicleDataSaver: IDataSaver<IVehicleData>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _dataMapper;

        public VehicleDataSaver(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _dataMapper = MapperField.GetMapper();
        }

        public async Task<bool> SavePictures(IVehicleData data, IDbConnection connection)
        {
            var pictures = data.PicturesDtos;
            if (!pictures.Any())
            {
                return true;
            }
            var retValue = true;
            var currentPictures = _dataMapper.Map<IEnumerable<PictureDto>, IEnumerable<PICTURES>>(pictures); 
            foreach (var entity in currentPictures)
            {
                if (connection.IsPresent<PICTURES>(entity))
                {
                    retValue = retValue && await connection.UpdateAsync(entity).ConfigureAwait(false);
                }
                else
                {
                    retValue = retValue && (await connection.InsertAsync(entity).ConfigureAwait(false) > 0);
                }
            }
            return retValue;

        }
        public async Task<bool> SaveAsync(IVehicleData vehicle)
        {

            var vehicleValue = vehicle.Value;
            var pocoValue = _dataMapper.Map<VehicleViewObject, VehiclePoco>(vehicleValue);
            VEHICULO1 vehiculo1 = _dataMapper.Map<VehiclePoco, VEHICULO1>(pocoValue);
            VEHICULO2 vehiculo2 = _dataMapper.Map<VehiclePoco, VEHICULO2>(pocoValue);
            vehiculo2.CODIINT = vehiculo1.CODIINT;
            bool retValue = true;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {

                using (TransactionScope transactionScope =
                new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    try
                    {
                        if (connection.IsPresent<VEHICULO1>(vehiculo1))
                        {
                            retValue = await connection.UpdateAsync(vehiculo1).ConfigureAwait(false);
                            retValue = retValue && await connection.UpdateAsync(vehiculo2).ConfigureAwait(false);
                        }
                        else
                        {
                            retValue = retValue && await connection.InsertAsync(vehiculo1)> 0;
                            retValue = retValue && await connection.InsertAsync(vehiculo2) > 0;
                        }
                        retValue = retValue && (await SavePictures(vehicle, connection).ConfigureAwait(false));
                        transactionScope.Complete();
                        return retValue;
                    }
                    catch (TransactionException ex)
                    {
                        // this is  an antipattern for exception handling.
                        string message = "Transaction Scope Exception in Vehicle Insertion. Reason: " + ex.Message;
                        var dataLayer = new DataLayerException(message);
                        throw dataLayer;
                    }
                    catch (System.Exception other)
                    {
                        string message = "Error in a Vehicle Insertion. Reason: " + other.Message;
                        var dataLayer = new DataLayerException(message);
                        throw dataLayer;
                    }

                }
            }
        }
    }
}
