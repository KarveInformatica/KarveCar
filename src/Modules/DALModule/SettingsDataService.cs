﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using KarveDapper.Extensions;
using KarveDapper;
using KarveDataServices;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer
{

    /// <summary>
    ///  This class is responsabile for the handling of the application settings. 
    /// For allowing multiple clients 
    /// </summary>
    internal class SettingsDataService : ISettingsDataServices
    {
        class DataCompare : IEqualityComparer<GRID_SERIALIZATION>
        {
            public bool Equals(GRID_SERIALIZATION x, GRID_SERIALIZATION y)
            {
                return (x.GRID_ID == y.GRID_ID);
            }

            public int GetHashCode(GRID_SERIALIZATION obj)
            {
                return obj.GetHashCode();
            }
        }

        private readonly ISqlExecutor _executorSql;

        /// <summary>
        ///  Settings data service.
        /// </summary>
        /// <param name="executor">Setting data service</param>
        public SettingsDataService(ISqlExecutor executor)
        {
            _executorSql = executor;
        }

        /// <summary>
        ///  Get magnifier settings by id.
        /// </summary>
        /// <param name="idValue">Identifier of the grid.</param>
        /// <returns></returns>
        public async Task<GridSettingsDto> GetMagnifierSettings(long idValue)
        {
            IMapper mapper = MapperField.GetMapper();
            GridSettingsDto settingsDto = new GridSettingsDto();
            if (_executorSql.State != ConnectionState.Open)
            {
                using (var dbConnection = _executorSql.OpenNewDbConnection())
                {


                    var dto = await dbConnection.GetAsync<GRID_SERIALIZATION>(idValue).ConfigureAwait(true);
                    if (dto != null)
                    {
                        settingsDto = mapper.Map<GRID_SERIALIZATION, GridSettingsDto>(dto);
                    }

                    return settingsDto;

                }
            }

            var settings = await _executorSql.Connection.GetAsync<GRID_SERIALIZATION>(idValue);
            settingsDto = mapper.Map<GRID_SERIALIZATION, GridSettingsDto>(settings);
            return settingsDto;
        }

        private async Task<bool> SaveOrUpdate(GRID_SERIALIZATION serialize)
        {
            bool value = false;
           
            using (var dbConnection = _executorSql.OpenNewDbConnection())
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try

                    {
                        if (string.IsNullOrEmpty(serialize.GRID_NAME))
                        {
                            serialize.GRID_NAME = "Unknown";
                        }
                        if (dbConnection.IsPresent<GRID_SERIALIZATION>(serialize))
                        {
                            // update
                          string updateSql = string.Format(GenericSql.GridSettingsUpdate, serialize.GRID_ID,
                                serialize.GRID_NAME, serialize.SERILIZED_DATA);
                            try
                            {
                                value = await dbConnection.ExecuteAsync(updateSql) > 0;

                            } catch(System.Exception e)
                            {
                                throw new DataLayerException(e.Message, e);
                            }
                        }
                        else
                        {

                            string insertSql = string.Format(GenericSql.GridSettingInsert, serialize.GRID_ID,
                                serialize.GRID_NAME, serialize.SERILIZED_DATA);
                            var executedInsert = await dbConnection.ExecuteAsync(insertSql);
                            value = executedInsert > 0;
                        }
                       transactionScope.Complete();
                    }
                    catch (System.Exception e)
                    {
                        throw new DataLayerException(e.Message, e);
                    }
                }
            }
            return value;
        }

        public async Task<bool> SaveMagnifierSettings(GridSettingsDto settingsDto)
        {
            Contract.Requires(settingsDto != null);
            bool value = false;
            IMapper mapper = MapperField.GetMapper();
            GRID_SERIALIZATION serialize = mapper.Map<GridSettingsDto, GRID_SERIALIZATION>(settingsDto);
            Contract.Requires(serialize != null);
            value = await SaveOrUpdate(serialize).ConfigureAwait(false);
            
            return value;
        }


        public async Task<ObservableCollection<GridSettingsDto>> GetMagnifierSettingByIds(List<long> registeredGridIds)
        {
            ObservableCollection<GRID_SERIALIZATION> settings = new ObservableCollection<GRID_SERIALIZATION>();
            Contract.Requires(registeredGridIds != null);
            using (var dbConnection = _executorSql.OpenNewDbConnection())
            {

                if (dbConnection != null)
                {
                    try
                    {
                        var dto = await dbConnection.GetAllAsync<GRID_SERIALIZATION>().ConfigureAwait(false);

                        var first = dto.OrderBy(x => x.GRID_ID).ToList();
                        foreach (var ids in registeredGridIds)
                        {
                            settings.Add(first.FirstOrDefault(x => x.GRID_ID == ids));

                        }
                    } catch (System.Exception e)
                    {
                        throw new DataLayerException(e.Message, e);
                    }
                }
            }
            var outSettings = MapperField.GetMapper()
                .Map<IEnumerable<GRID_SERIALIZATION>, ObservableCollection<GridSettingsDto>>(settings);
            return outSettings;
        }
    }
}