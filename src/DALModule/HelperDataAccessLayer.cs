﻿using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.MappedStatements;

namespace DataAccessLayer
{
    /// <summary>
    ///  This class has some helper methods that retrives values needed.
    /// </summary>
    class HelperDataAccessLayer : BaseDataMapper, IHelperDataServices
    {
        private IDataMapper dataMapper;

        public HelperDataAccessLayer(IDataMapper dataMapper)
        {
            this.dataMapper = dataMapper;
        }

        /// <summary>
        ///  This method returns two table in the data set: The province table and the countries.
        ///  It works in batch mode.
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncCountriesAndProvinces()
        {
            IMapperCommand mapper1 = new QueryAsyncForDataTableCommand("Suppliers.GetAllProvinces", null);
            IMapperCommand mapper2 = new QueryAsyncForDataTableCommand("Suppliers.GetAllCountries", null);
            DataMapper.AddBatch(mapper1);
            DataMapper.AddBatch(mapper2);
            DataSet set = await DataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
            return set;
        }
    }
}
