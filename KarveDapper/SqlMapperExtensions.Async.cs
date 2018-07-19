using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;

/// <summary>
/// Karve Informatica Extensions for the Sysbase Dapper.
///  This allows us to use dapper in safe way with support for sybase.
/// </summary>
namespace KarveDapper.Extensions
{
    public static partial class SqlMapperExtensions
    {
        /// <summary>
        /// Returns a single entity by a single id from table "Ts" asynchronously using .NET 4.5 Task. T must be of interface type. 
        /// Id must be marked with [Key] attribute.
        /// Created entity is tracked/intercepted for changes and used by the Update() extension. 
        /// </summary>
        /// <typeparam name="T">Interface type to create and populate</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="id">Id of the entity to get, must be marked with [Key] attribute</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>Entity of T</returns>
        public static async Task<T> GetAsync<T>(this IDbConnection connection, dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            if (!GetQueries.TryGetValue(type.TypeHandle, out string sql))
            {
                var key = GetSingleKey<T>(nameof(GetAsync));
                var name = GetTableName(type);

                sql = $"SELECT * FROM {name} WHERE {key.Name} = ?id?";
                GetQueries[type.TypeHandle] = sql;
            }

            var dynParms = new DynamicParameters();
            dynParms.Add("@id", id);

            if (!type.IsInterface)
                return (await connection.QueryAsync<T>(sql, dynParms, transaction, commandTimeout).ConfigureAwait(false)).FirstOrDefault();

            var res = (await connection.QueryAsync<dynamic>(sql, dynParms).ConfigureAwait(false)).FirstOrDefault() as IDictionary<string, object>;

            if (res == null)
                return null;

            var obj = ProxyGenerator.GetInterfaceProxy<T>();

            foreach (var property in TypePropertiesCache(type))
            {
                var val = res[property.Name];
                property.SetValue(obj, Convert.ChangeType(val, property.PropertyType), null);
            }

            ((IProxy)obj).IsDirty = false;   //reset change tracking and return

            return obj;
        }

        public static async Task<T> GetRandomEntityAsync<T>(this IDbConnection connection, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var firstHundred = await GetPagedAsync<T>(connection, 1, 100, "", transaction, commandTimeout).ConfigureAwait(false);
            Random random = new Random();
            var number = random.Next(99);
            if (firstHundred.Count()> number)
            {
                return firstHundred.ElementAt(number);
            }
            return firstHundred.FirstOrDefault();
        }
        /// <summary>
        /// Returns a list of entites from table "Ts".  
        /// Id of T must be marked with [Key] attribute.
        /// Entities created from interfaces are tracked/intercepted for changes and used by the Update() extension
        /// for optimal performance. 
        /// </summary>
        /// <typeparam name="T">Interface or type to create and populate</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>Entity of T</returns>
        public static Task<IEnumerable<T>> GetAllAsync<T>(this IDbConnection connection, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            var cacheType = typeof(List<T>);

            if (!GetQueries.TryGetValue(cacheType.TypeHandle, out string sql))
            {
                GetSingleKey<T>(nameof(GetAll));
                var name = GetTableName(type);

                sql = "SELECT * FROM " + name;
                GetQueries[cacheType.TypeHandle] = sql;
            }

            if (!type.IsInterface)
            {
                return connection.QueryAsync<T>(sql, null, transaction, commandTimeout);
            }
            return GetAllAsyncImpl<T>(connection, transaction, commandTimeout, sql, type);
        }

        /// <summary>
        ///  Returns a tuple where the first item is the number of items in database and the second item is the number of pages.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="tableName"></param>
        /// <returns>A tuple containing as first item the number of items, and the second items the number of pages</returns>
        public static async Task<Tuple<int, int>> GetPageCount<T>(this IDbConnection connection, int pageSize = 100)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            // find a smart way to get the query 
            var type = typeof(T);
            var tableName = GetTableName(type);
            var value = "SELECT COUNT(*) FROM " + tableName;
            var pageCount = 0;
            var numItems = 0; 
            var numEnumerable =  await connection.QueryAsync<int>(value);
            numItems = numEnumerable.FirstOrDefault();
            
            double items = numItems;
            double pageDim = pageSize;
            pageCount = (int)Math.Round(items / pageDim);
            return new Tuple<int, int>(numItems, pageCount);
        }


        /// <summary>
        /// This is a paged asynchronous.
        /// </summary>
        /// <typeparam name="T">Type of the summary</typeparam>
        /// <param name="connection">Type of the connection</param>
        /// <param name="index">Index where to start asking for th query</param>
        /// <param name="pageSize">Dimension of the page</param>
        /// <param name="transaction">Transacion</param>
        /// <param name="commandTimeout">Timeout</param>
        /// <returns>The list of paged filtered</returns>
        public static async Task<IEnumerable<T>> GetPagedAsync<T>(this IDbConnection connection, 
            long index, 
            long pageSize,
            string filter = "",
            IDbTransaction transaction = null,
            int? commandTimeout = null ) where T : class
        {
            if ((index <= 0)  || (pageSize <=0))
            {
                throw new System.ArgumentOutOfRangeException("Index " + index  + " and pageSize shall be positive, pageSize " + pageSize);
            }
            var type = typeof(T);
            var name = GetTableName(type);
            var baseString = "SELECT TOP {0} START AT {1} * FROM ";
            var queryValue = "";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                var formatString = baseString + name + " WHERE " + filter;
                queryValue = string.Format(formatString, pageSize, index);
            }
            else
            {
                var formatString = baseString + name;
                queryValue = string.Format(formatString, pageSize, index);
            }
            var returnValue = await connection.QueryAsync<T>(queryValue);
            return returnValue;
        }
        
        private static async Task<IEnumerable<T>> GetAllAsyncImpl<T>(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string sql, Type type) where T : class
        {
            var result = await connection.QueryAsync(sql).ConfigureAwait(false);
            var list = new List<T>();
            foreach (IDictionary<string, object> res in result)
            {
                var obj = ProxyGenerator.GetInterfaceProxy<T>();
                foreach (var property in TypePropertiesCache(type))
                {
                    var val = res[property.Name];
                    property.SetValue(obj, Convert.ChangeType(val, property.PropertyType), null);
                }
                ((IProxy)obj).IsDirty = false;   //reset change tracking and return
                list.Add(obj);
            }
            return list;
        }


        /// <summary>
        /// Inserts an entity into table "Ts" asynchronously using .NET 4.5 Task and returns identity id.
        /// </summary>
        /// <typeparam name="T">The type being inserted.</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToInsert">Entity to insert</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <param name="sqlAdapter">The specific ISqlAdapter to use, auto-detected based on connection if null</param>
        /// <returns>Identity of inserted entity</returns>
        public static Task<int> InsertAsync<T>(this IDbConnection connection, T entityToInsert, IDbTransaction transaction = null,
            int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class
        {
            var type = typeof(T);
            sqlAdapter = sqlAdapter ?? GetFormatter(connection);

            var isList = false;
            if (type.IsArray)
            {
                isList = true;
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                isList = true;
                type = type.GetGenericArguments()[0];
            }

            var name = GetTableName(type);
            var sbColumnList = new StringBuilder(null);
            var allProperties = TypePropertiesCache(type);
            var keyProperties = KeyPropertiesCache(type);
            var computedProperties = ComputedPropertiesCache(type);
            // our internal database is not able to handle well keys.
            var allPropertiesExceptKeyAndComputed = allProperties.ToList();
            //.Except(keyProperties.Union(computedProperties)).ToList();

            for (var i = 0; i < allPropertiesExceptKeyAndComputed.Count; i++)
            {
                var property = allPropertiesExceptKeyAndComputed[i];
                sqlAdapter.AppendColumnName(sbColumnList, property.Name);
                if (i < allPropertiesExceptKeyAndComputed.Count - 1)
                    sbColumnList.Append(", ");
            }

            var sbParameterList = new StringBuilder(null);
            for (var i = 0; i < allPropertiesExceptKeyAndComputed.Count; i++)
            {
                var property = allPropertiesExceptKeyAndComputed[i];
                sbParameterList.AppendFormat("?{0}?", property.Name);
                if (i < allPropertiesExceptKeyAndComputed.Count - 1)
                    sbParameterList.Append(", ");
            }

            if (!isList)    //single entity
            {
                return sqlAdapter.InsertAsync(connection, transaction, commandTimeout, name, sbColumnList.ToString(),
                    sbParameterList.ToString(), keyProperties, entityToInsert);
            }

            //insert list of entities
            var cmd = $"INSERT INTO {name} ({sbColumnList}) values ({sbParameterList})";

            return connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout);
        }

        /// <summary>
        /// Updates entity in table "Ts" asynchronously using .NET 4.5 Task, checks if the entity is modified if the entity is tracked by the Get() extension.
        /// </summary>
        /// <typeparam name="T">Type to be updated</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToUpdate">Entity to be updated</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if updated, false if not found or not modified (tracked entities)</returns>
        public static async Task<bool> UpdateAsync<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if ((entityToUpdate is IProxy proxy) && !proxy.IsDirty)
            {
                return false;
            }

            var type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            var keyProperties = KeyPropertiesCache(type);
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);
            if (keyProperties.Count == 0 && explicitKeyProperties.Count == 0)
                throw new ArgumentException("Entity must have at least one [Key] or [ExplicitKey] property");

            var name = GetTableName(type);

            var sb = new StringBuilder();
            sb.AppendFormat("update {0} set ", name);

            var allProperties = TypePropertiesCache(type);
            keyProperties.AddRange(explicitKeyProperties);
            var computedProperties = ComputedPropertiesCache(type);
            var nonIdProps = allProperties.Except(keyProperties.Union(computedProperties)).ToList();

            var adapter = GetFormatter(connection);

            for (var i = 0; i < nonIdProps.Count; i++)
            {
                var property = nonIdProps[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < nonIdProps.Count - 1)
                    sb.AppendFormat(", ");
            }
            sb.Append(" where ");
            for (var i = 0; i < keyProperties.Count; i++)
            {
                var property = keyProperties[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < keyProperties.Count - 1)
                    sb.AppendFormat(" and ");
            }
            string value = sb.ToString();
            int updated = 0;
            try
            {
               updated = await connection.ExecuteAsync(sb.ToString(), entityToUpdate, commandTimeout: commandTimeout, transaction: transaction).ConfigureAwait(false);
            } catch (Exception e)
            {
                var ex = e.Message;
            }
            return updated > 0;
        }
        /// <summary>
        ///  This returns all the entities from a table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetAsyncAll<T>(this IDbConnection connection) where T : class
        {
            var type = typeof(T);
            var name = GetTableName(type);
            var value = "SELECT * FROM " + name + ";";
            var returnValue = await connection.QueryAsync<T>(value);
            return returnValue;
        }


        /// <summary>
        ///  This method is used for generate an unique number for  a primary key:
        ///  1. It generate 8 bytes from a crypto random generator.
        ///  2. Converts to long
        ///  3. Truncate the bytes to the primary key fieldsize or to 6.
        ///  4. Check if an entity with that value exists.
        /// </summary>
        /// <typeparam name="T">Entity type to be checked</typeparam>
        /// <param name="connection">Connection to be extended.</param>
        /// <param name="entityValue">EntityValue</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="commandTimeout">Timeout</param>
        /// <returns></returns>
        public static async Task<string> UniqueIdAsync<T>(this IDbConnection connection, T entityValue,
            IDbTransaction transaction = null,
            int? commandTimeout = null) where T : class
        {

            var type = typeof(T);
            var name = GetTableName(type);
            PropertyInfo info = GetKeyAttribute<T>(entityValue);
            int fieldSize = GetFieldSize<T>(entityValue);
            StringBuilder builder = new StringBuilder();
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            ulong value = 0;
            IEnumerable<T> collection = null;
            int tries = 0;
            string id = String.Empty;
            do
            {
                var byteArray = new byte[8];
                provider.GetBytes(byteArray);
                //convert 8 bytes to a long
                try
                {
                    value = BitConverter.ToUInt64(byteArray, 0);

                }
                catch (Exception e)
                {
                    var v = e;
                }
                if (info != null)
                {
                    // ok this is a unique id. 6 is the default field size.
                    if (fieldSize == 0)
                    {
                        fieldSize = 6;
                    }
                    id = value.ToString().Substring(0, fieldSize);
                    id = id.PadLeft(fieldSize, '0');
                    builder.Append(" WHERE ");
                    builder.Append(info.Name);
                    builder.Append("=");
                    builder.Append(string.Format("'{0}'", id));
                    var statement = $"select * from {name} " + builder.ToString();
                    collection = await connection.QueryAsync<T>(statement);
                    ++tries;
                }
            } while ((collection.Count() != 0) && (tries < 10));
            return id;
        }



        static ulong GenerateBigNumber()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            ulong value = 0;
            var byteArray = new byte[8];
            provider.GetBytes(byteArray);
            try
            {
                value = BitConverter.ToUInt64(byteArray, 0);

            }
#pragma warning disable 0168
            catch (Exception e)
            {
#pragma warning restore 0168
                value = ulong.MaxValue;
            }
            return value;
        }
        static Tuple<string,string> ExtractQueryFromNumber(ulong value, string primaryKey, string name, int fieldSize)
        {

            StringBuilder builder = new StringBuilder();
            var id = value.ToString().Substring(0, fieldSize);
            id = id.PadLeft(fieldSize, '0');
            builder.Append(" WHERE ");
            builder.Append(primaryKey);
            builder.Append("=");
            builder.Append($"'{id}'");
            var statement = $"select * from {name} " + builder.ToString();
            return new Tuple<string,string>(statement, id);

        }
        /// <summary>
        ///  This method is used for generate an unique number for  a primary key:
        ///  1. It generate 8 bytes from a crypto random generator.
        ///  2. Converts to long
        ///  3. Truncate the bytes to the primary key fieldsize or to 6.
        ///  4. Check if an entity with that value exists.
        /// </summary>
        /// <typeparam name="T">Entity type to be checked</typeparam>
        /// <param name="connection">Connection to be extended.</param>
        /// <param name="entityValue">EntityValue</param>
        /// <param name="transaction">Transaction</param>
        /// <param name="commandTimeout">Timeout</param>
        /// <returns></returns>
        public static string UniqueId<T>(this IDbConnection connection, T entityValue,
            IDbTransaction transaction = null,
            int? commandTimeout = null) where T : class
        {

            var type = typeof(T);
            var name = GetTableName(type);
            PropertyInfo info = GetKeyAttribute<T>(entityValue);
            int fieldSize = GetFieldSize<T>(entityValue);
            StringBuilder builder = new StringBuilder();
            IEnumerable<T> collection = null;
            int tries = 0;
            string id = String.Empty;
            if (fieldSize == 0)
            {
                fieldSize = 6;
            }
            do
            {
                var value = GenerateBigNumber();
                if (info != null)
                {
                    // ok this is a unique id. 6 is the default field size.
                    var statement = ExtractQueryFromNumber(value, info.Name, name, fieldSize);
                    id = statement.Item2;
                    try
                    {
                        collection = connection.Query<T>(statement.Item1);
                    }
                    finally 
                    {
                        ++tries;
                   
                    }
                }
            } while ((collection.Count() != 0) && (tries < 20));
            if (collection.Count() != 0)
            {
                var statement = "SELECT count(*) from {name};";
                try
                {
                    var number = connection.Query<T>(statement);
                    var item = number.FirstOrDefault();
                    id = item.ToString();
                }
#pragma warning disable 0168
                catch (Exception e)
                {
#pragma warning restore 0168
                    collection = new List<T>();
                }
            }
            return id;
        }
        /// <summary>
        /// This deletes a collection of entities.
        /// </summary>
        /// <typeparam name="T">Type of the entities</typeparam>
        /// <param name="connection">Current connection</param>
        /// <param name="entityToDelete">Collection of entities to delete</param>
        /// <param name="transaction">Simple transaction</param>
        /// <param name="commandTimeout">Command timeout</param>
        /// <returns></returns>
        public static async Task<bool> DeleteCollectionAsync<T>(this IDbConnection connection, IEnumerable<T> entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            var keyProperties = KeyPropertiesCache(type);
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);

            var name = GetTableName(type);
            keyProperties.AddRange(explicitKeyProperties);

            var sb = new StringBuilder();
            var maxNumber = entityToDelete.Count<T>();
            var currentList = entityToDelete.AsList<T>();
            for (var numEntity = 0; numEntity < maxNumber; numEntity++)
            {

                sb.AppendFormat("DELETE FROM {0} WHERE ", name);
                var currentEntity = currentList[numEntity];
                for (var i = 0; i < keyProperties.Count; i++)
                {
                    var property = keyProperties[i];
                    sb.AppendFormat("{0}='{1}'", property.Name, property.GetValue(currentEntity).ToString());
                    if (i < keyProperties.Count - 1)
                        sb.AppendFormat(" AND ");
                }
                if (numEntity < currentList.Count - 1)
                {
                    sb.Append(";");
                }
            }
            var query = sb.ToString();
            var deleted = await connection.ExecuteAsync(sb.ToString(), null, transaction, commandTimeout).ConfigureAwait(false);
            return deleted > 0;

        }
        /// <summary>
        /// This updates a collection of entities.
        /// </summary>
        /// <typeparam name="T">Type of the entities</typeparam>
        /// <param name="connection">Current connection</param>
        /// <param name="entityToDelete">Collection of entities to delete</param>
        /// <param name="transaction">Simple transaction</param>
        /// <param name="commandTimeout">Command timeout</param>
        /// <returns></returns>
        public static async Task<bool> ExecuteUpdateCollectionAsync<T>(this IDbConnection connection, IEnumerable<T> entitiesToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {

            StringBuilder currentBuilder = new StringBuilder();
            var toUpdate = entitiesToUpdate as T[] ?? entitiesToUpdate.ToArray();
            var maxNumber = toUpdate.Count<T>();
            T entityToUpdate = toUpdate.FirstOrDefault<T>();
            var type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            var keyProperties = KeyPropertiesCache(type);
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);
            if (keyProperties.Count == 0 && explicitKeyProperties.Count == 0)
                throw new ArgumentException("Entity must have at least one [Key] or [ExplicitKey] property");
            var name = GetTableName(type);
            var sb = new StringBuilder();
            sb.AppendFormat("update {0} set ", name);

            var allProperties = TypePropertiesCache(type);
            keyProperties.AddRange(explicitKeyProperties);
            var computedProperties = ComputedPropertiesCache(type);
            var nonIdProps = allProperties.Except(keyProperties.Union(computedProperties)).ToList();

            var adapter = GetFormatter(connection);

            for (var i = 0; i < nonIdProps.Count; i++)
            {
                var property = nonIdProps[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < nonIdProps.Count - 1)
                    sb.AppendFormat(", ");
            }
            sb.Append(" where ");
            for (var i = 0; i < keyProperties.Count; i++)
            {
                var property = keyProperties[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < keyProperties.Count - 1)
                    sb.AppendFormat(" and ");
            }
            currentBuilder.Append(sb.ToString());
            sb.Clear();
            string value = currentBuilder.ToString();
            int updated = 0;
            try
            {
                updated = await connection
                    .ExecuteAsync(value, entitiesToUpdate, commandTimeout: commandTimeout, transaction: transaction)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new DataException(e.Message,e);
            }

            return updated > 0;
        }

        /// <summary>
        /// Delete entity in table "Ts" asynchronously using .NET 4.5 Task.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToDelete">Entity to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<bool> DeleteAsync<T>(this IDbConnection connection, T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (entityToDelete == null)
                throw new ArgumentException("Cannot Delete null Object", nameof(entityToDelete));

            var type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }

            var keyProperties = KeyPropertiesCache(type);
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);
            if (keyProperties.Count == 0 && explicitKeyProperties.Count == 0)
                throw new ArgumentException("Entity must have at least one [Key] or [ExplicitKey] property");

            var name = GetTableName(type);
            keyProperties.AddRange(explicitKeyProperties);

            var sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM {0} WHERE ", name);

            for (var i = 0; i < keyProperties.Count; i++)
            {
                var property = keyProperties[i];
                sb.AppendFormat("{0} = ?{1}?", property.Name, property.Name);
                if (i < keyProperties.Count - 1)
                    sb.AppendFormat(" AND ");
            }
            var deleted = await connection.ExecuteAsync(sb.ToString(), entityToDelete, transaction, commandTimeout).ConfigureAwait(false);
            return deleted > 0;
        }

        /// <summary>
        /// Delete all entities in the table related to the type T asynchronously using .NET 4.5 Task.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if none found</returns>
        public static async Task<bool> DeleteAllAsync<T>(this IDbConnection connection, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            var statement = "DELETE FROM " + GetTableName(type);
            var deleted = await connection.ExecuteAsync(statement, null, transaction, commandTimeout).ConfigureAwait(false);
            return deleted > 0;
        }
    }

    public partial interface ISqlAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert);
        /// <summary>
        ///  This is a way to insert a list of connectin.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="tableName"></param>
        /// <param name="columnList"></param>
        /// <param name="parameterList"></param>
        /// <param name="keyProperties"></param>
        /// <param name="entityArrayToInsert"></param>
        /// <returns></returns>
        Task<int> InsertCollectionAsync<T>(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, IEnumerable<T> entityArrayToInsert);
    }



    public partial class SybaseAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        ///  KarveTeam: We keep this simple because it is important. The original dapper.contrib in SQLServer was using queryMultiple.
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var cmd = $"INSERT INTO {tableName} ({columnList}) values ({parameterList});";
            var affectedRows = await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);


            return affectedRows;
        }
        public async Task<int> InsertCollectionAsync<T>(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, IEnumerable<T> entityArrayToInsert)
        {
            
            var cmd = $"INSERT INTO {tableName} ({columnList}) values ({parameterList});";
            var affectedRows = await connection.ExecuteAsync(cmd, entityArrayToInsert, transaction, commandTimeout).ConfigureAwait(false);


            return affectedRows;
        }



    }

    public partial class SqlServerAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var cmd = $"INSERT INTO {tableName} ({columnList}) values ({parameterList}); SELECT SCOPE_IDENTITY() id";
            var multi = await connection.QueryMultipleAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

            var first = multi.Read().FirstOrDefault();
            if (first == null || first.id == null) return 0;

            var id = (int)first.id;
            var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
            if (pi.Length == 0) return id;

            var idp = pi[0];
            idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

            return id;
        }
    }

    public partial class SqlCeServerAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var cmd = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList})";
            await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);
            var r = (await connection.QueryAsync<dynamic>("SELECT @@IDENTITY id", transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false)).ToList();

            if (r[0] == null || r[0].id == null) return 0;
            var id = (int)r[0].id;

            var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
            if (pi.Length == 0) return id;

            var idp = pi[0];
            idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

            return id;
        }
    }

    public partial class MySqlAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName,
            string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var cmd = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList});";
            await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);
            var r = await connection.QueryAsync<dynamic>("SELECT LAST_INSERT_ID() id", transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false);

            var id = r.First().id;
            if (id == null) return 0;
            var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
            if (pi.Length == 0) return Convert.ToInt32(id);

            var idp = pi[0];
            idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

            return Convert.ToInt32(id);
        }
    }

    public partial class PostgresAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", tableName, columnList, parameterList);

            // If no primary key then safe to assume a join table with not too much data to return
            var propertyInfos = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
            if (propertyInfos.Length == 0)
            {
                sb.Append(" RETURNING *");
            }
            else
            {
                sb.Append(" RETURNING ");
                bool first = true;
                foreach (var property in propertyInfos)
                {
                    if (!first)
                        sb.Append(", ");
                    first = false;
                    sb.Append(property.Name);
                }
            }

            var results = await connection.QueryAsync(sb.ToString(), entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

            // Return the key by assinging the corresponding property in the object - by product is that it supports compound primary keys
            var id = 0;
            foreach (var p in propertyInfos)
            {
                var value = ((IDictionary<string, object>)results.First())[p.Name.ToLower()];
                p.SetValue(entityToInsert, value, null);
                if (id == 0)
                    id = Convert.ToInt32(value);
            }
            return id;
        }
    }

    public partial class SQLiteAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var cmd = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList}); SELECT last_insert_rowid() id";
            var multi = await connection.QueryMultipleAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

            var id = (int)multi.Read().First().id;
            var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
            if (pi.Length == 0) return id;

            var idp = pi[0];
            idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

            return id;
        }
    }

    public partial class FbAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
        {
            var cmd = $"insert into {tableName} ({columnList}) values ({parameterList})";
            await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

            var propertyInfos = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
            var keyName = propertyInfos[0].Name;
            var r = await connection.QueryAsync($"SELECT FIRST 1 {keyName} ID FROM {tableName} ORDER BY {keyName} DESC", transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false);

            var id = r.First().ID;
            if (id == null) return 0;
            if (propertyInfos.Length == 0) return Convert.ToInt32(id);

            var idp = propertyInfos[0];
            idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

            return Convert.ToInt32(id);
        }
    }
}