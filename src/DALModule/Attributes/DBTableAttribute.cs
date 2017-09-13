using System;

namespace DataAccessLayer.DataObjects.Attributes
{
    class DBTableAttribute : Attribute
    {
        private string _databaseTable;
        private string _databaseProvider;
        public DBTableAttribute(string databaseTable)
        {
            this._databaseTable = databaseTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">Database table</param>
        /// <param name="provider">Database provider</param>
        public DBTableAttribute(string table, string provider)
        {
            this._databaseTable = table;
            this._databaseProvider = provider;
        }
    }
}