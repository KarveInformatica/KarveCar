using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using AutoMapper;
using DataAccessLayer.Logic;
using DataAccessLayer.DataObjects;
using System.Data;

namespace DataAccessLayer.Crud.Company
{
    class CompanyDataSaver : IDataSaver<CompanyDto>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        
        public CompanyDataSaver(ISqlExecutor sqlExecutor)
        {
            this._sqlExecutor = sqlExecutor;
            this._mapper = MapperField.GetMapper();
        }
        /// <summary>
        ///  This save the company correctly.
        /// </summary>
        /// <param name="dtoToSave">Company to save</param>
        /// <returns>True if the company has been saved.</returns>
        public async Task<bool> SaveAsync(CompanyDto dtoToSave)
        {
            var entity = _mapper.Map<CompanyDto, SUBLICEN>(dtoToSave);
            bool retValue = false;
            using (IDbConnection conn = this._sqlExecutor.OpenNewDbConnection())
            {
                if (!conn.IsPresent<SUBLICEN>(entity))
                {
                    retValue = await conn.InsertAsync<SUBLICEN>(entity) > 0;
                }
                else
                {
                    retValue = await conn.UpdateAsync<SUBLICEN>(entity);
                }
            }
            return true;
        }

    }
}
