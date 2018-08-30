using System.Linq;
using Dapper;
using DataAccessLayer.DtoWrapper;
using DataAccessLayer.SQL;

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Crud;
    using DataObjects;
    using KarveCommonInterfaces;
    using KarveDataServices;
    using KarveDataServices.DataObjects;
    using KarveDataServices.ViewObjects;

    /// <summary>
    /// Service for retrieving the users and managing the users.
    /// </summary>
    internal class UserDataService : AbstractDataAccessLayer, IUserDataService
    {
        
        /// <summary>
        /// Data loader.
        /// </summary>
        private IDataLoader<UserViewObject> loader;
        /// <summary>
        ///  sql executor.
        /// </summary>
        private ISqlExecutor sqlExecutor;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataService"/> class.
        /// </summary>
        /// <param name="executor">
        /// The executor.
        /// </param>
        public UserDataService(ISqlExecutor executor) : base(executor)
        {
            this.sqlExecutor = executor;
            
            this.loader = new DataLoader<USURE, UserViewObject>(executor);
        }

        /// <summary>
        ///  Retrieve the number of page count.
        /// </summary>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>

        public Task<int> GetPageCount(int pageSize)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Page number. Retrieve the number of pages.
        /// </summary>
        public int NumberPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long NumberItems { get; set; }
        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string NewId()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrieve the list of summary user views.
        /// </summary>
        /// <returns>A list of user view objects</returns>
        public async Task<IEnumerable<UserSummaryViewObject>> GetSummaryAllAsync()
        {
            var store = this.QueryStoreFactory.GetQueryStore();
            IEnumerable<UserSummaryViewObject> userView = new List<UserSummaryViewObject>();
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                store.AddParam(QueryType.QueryUserSummary);
                var query = store.BuildQuery();
                userView = await conn.QueryAsync<UserSummaryViewObject>(query).ConfigureAwait(false);
            }
            return userView;
        }

        public async Task<IUserData> GetDoAsync(string code)
        {
            IUserData user = new User();
            user.Valid = false;
            try
            {
                var data = await loader.LoadValueAsync(code).ConfigureAwait(false);
                user.Value = data;
            }
            catch (System.Exception ex)
            {
                throw new DataLayerException("User exception", ex);               
            }
            user.Valid = true;
            return user;
        }


        public Task<bool> SaveAsync(IUserData data)
        {
            throw new NotImplementedException();
        }

        public IUserData GetNewDo(string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IUserData data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSummaryViewObject>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUserData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSummaryViewObject>> SearchByDate(DateTime? @from, DateTime? to)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSummaryViewObject>> SearchByFilter(IQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSummaryViewObject>> SearchByDatePaged(DateTime? @from, DateTime? to, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserSummaryViewObject>> SearchByFilterPaged(IQueryFilter filter, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IUserData> SearchSingleByFilter(IQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IUserData> SearchSingleByProperty(string name, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Retrieve the user data from the user name.
        /// </summary>
        /// <param name="name">Username to be used.</param>
        /// <returns>A data containing user information</returns>

        public async Task<IUserData> GetUserByName(string name)
        {
            var store = this.QueryStoreFactory.GetQueryStore();
            IUserData user = new User() { Valid = false };
            user.Value = new UserViewObject();
            bool foundUser = false;
            
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                store.AddParam(QueryType.QueryUserByName, name);
                var query = store.BuildQuery();
               var userValue = await conn.QueryAsync<USURE>(query).ConfigureAwait(false);
                if (userValue.Count()>0)
                {
                    var singleUser = userValue.FirstOrDefault();
                 
                    user.Value.OFI_COD = singleUser.OFI_COD;
                    user.Value.NOMBRE = singleUser.NOMBRE;
                    user.Value.PASS = singleUser.PASS;
                    user.Value.CODIGO = singleUser.CODIGO;
                    foundUser = true;
                }
            }

            if (foundUser)
            {
               // var office = await this.FetchOffice(user.Value.OFI_COD).ConfigureAwait(false);
               // user.Office = ;
            }

            return user;
        }

        /// <summary>
        ///  Office code
        /// </summary>
        /// <param name="code">Codigo for the office</param>
        /// <returns>An office object</returns>
        private async Task<OfficeViewObject> FetchOffice(string code)
        {
            var store = this.QueryStoreFactory.GetQueryStore();
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                store.AddParam(QueryType.QueryOffice, code);
                var query = store.BuildQuery();
                var result = await conn.QueryFirstOrDefaultAsync<OFICINAS>(query);
                if (result != null)
                {
                    var officeView = Mapper.Map<OFICINAS, OfficeViewObject>(result);
                    return officeView;
                }
            }
            return new OfficeViewObject();
        }
    }
}
